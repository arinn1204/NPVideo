﻿CREATE PROCEDURE [video].[usp_add_tv_episode] (
	@series_imdb_id VARCHAR(32),
    @series_title VARCHAR(MAX),
    @mpaa_rating VARCHAR(8),
	@series_plot VARCHAR(MAX),
	@series_release_date DATETIME,
	@episode_imdb_id VARCHAR(32),
    @runtime DECIMAL(5, 2),
    @episode_release_date DATETIME,
	@season_number INT,
	@episode_number INT,
	@episode_name VARCHAR(MAX),
    @plot VARCHAR(MAX),
    @resolution VARCHAR(16) = NULL,
    @codec VARCHAR(8) = NULL,
	@extended VARCHAR(16) = NULL,
    @GENRES genre_table_type READONLY,
    @PERSONS person_table_type READONLY,
    @RATINGS rating_table_type READONLY)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @series_video_id INT,
				@created_time DATETIME = GETDATE(),
				@created_user VARCHAR(32) = (SELECT SYSTEM_USER),
				@is_updated BIT = 0;

			CREATE TABLE #Episode(
				id INT,
				name VARCHAR(MAX),
				category VARCHAR(MAX)
			);

			EXECUTE video.usp_add_movie_or_series
				@series_imdb_id,
				@series_title,
				@mpaa_rating,
				null,
				@series_plot,
				'series',
				@series_release_date,
				null,
				null,
				null,
				@GENRES,
				@PERSONS,
				@RATINGS;

				
			SELECT @series_video_id = video_id
				FROM video.videos
				WHERE imdb_id = @series_imdb_id
					AND video_type = 'series'
					AND title = @series_title
					AND mpaa_rating = @mpaa_rating
					AND plot = @series_plot
					AND release_date = @series_release_date;

			IF NOT EXISTS (SELECT 1
				FROM video.tv_episodes
				WHERE video_id = @series_video_id
					AND tv_episode_imdb_id = @episode_imdb_id
					AND season_number = @season_number
					AND episode_number = @episode_number
					AND episode_name = @episode_name
					AND release_date = @episode_release_date
					AND plot = @plot
					AND (resolution = @resolution OR resolution IS NULL AND @resolution IS NULL)
					AND (codec = @codec OR codec IS NULL AND @codec IS NULL)
					AND (extended_edition = @extended OR extended_edition IS NULL AND @extended IS NULL))
				BEGIN
					MERGE video.tv_episodes AS target
					USING (SELECT @series_video_id AS 'video_id', 
								@episode_imdb_id AS 'imdb_id', 
								@season_number AS 'season_number', 
								@episode_number AS 'episode_number',
								@episode_name AS 'name', 
								@episode_release_date AS 'release_date',
								@plot AS 'plot',
								@resolution AS 'resolution',
								@codec AS 'codec',
								@extended AS 'extended',
								@created_time AS 'ctime',
								@created_user AS 'cuser') AS source
					ON ((SELECT 1 
							FROM video.tv_episodes 
							WHERE tv_episode_imdb_id = @episode_imdb_id) IS NOT NULL
						AND (SELECT 1
								FROM video.tv_episodes
								WHERE video_id = @series_video_id
									AND tv_episode_imdb_id = @episode_imdb_id
									AND season_number = @season_number
									AND episode_number = @episode_number
									AND episode_name = @episode_name
									AND release_date = @episode_release_date
									AND plot = @plot) IS NULL)
					WHEN NOT MATCHED THEN
						INSERT (video_id, tv_episode_imdb_id, season_number, episode_number, episode_name, release_date, plot, resolution, codec, extended_edition, added, created_by)
							VALUES(source.video_id, source.imdb_id, source.season_number, source.episode_number, source.name, source.release_date, source.plot, source.resolution, source.codec, source.extended, source.ctime, source.cuser)
					WHEN MATCHED THEN
						UPDATE 
							SET season_number = source.season_number,
								episode_number = source.episode_number,
								episode_name = source.name,
								release_date = source.release_date,
								plot = source.plot,
								resolution = source.resolution,
								codec = source.codec,
								extended_edition = source.extended,
								modified = source.ctime,
								modified_by = source.cuser,
								@is_updated = 1
					OUTPUT INSERTED.tv_episode_id, 'INSERTED_TV_EPISODE_ID'
						INTO #Episode(id, category);
				END

			INSERT INTO #Episode(id, category)
				SELECT tv_episode_id, 'TV_EPISODE_ID'
				FROM video.tv_episodes
				WHERE tv_episode_imdb_id = @episode_imdb_id;

            MERGE INTO video.ratings AS target
			USING (
				SELECT r.source AS 'ratings_source', r.value AS 'ratings_value', v.id 
				FROM @RATINGS r
				INNER JOIN #Episode v
					ON v.category = 'TV_EPISODE_ID'
			) AS source
			ON target.video_id = @series_video_id
				AND target.tv_episode_id = source.id
			WHEN NOT MATCHED THEN
				INSERT (video_id, tv_episode_id, source, value, added, created_by)
					VALUES(@series_video_id, source.id, source.ratings_source, source.ratings_value, @created_time, @created_user);

		
			MERGE INTO video.genre_tv_episodes AS target
			USING (
				SELECT g.genre_id, ilv.id AS 'episode_id'
				FROM video.genres g
				INNER JOIN @GENRES gtt
					ON gtt.name = g.name
				INNER JOIN (SELECT id FROM #Episode WHERE category = 'TV_EPISODE_ID') ilv
					ON ilv.id IS NOT NULL
			) AS source
			ON target.genre_id = source.genre_id 
				AND target.tv_episode_id = source.episode_id
			WHEN NOT MATCHED THEN
				INSERT (tv_episode_id, genre_id)
				VALUES (source.episode_id, source.genre_id);

			
			MERGE INTO video.person_tv_episodes AS target
			USING (
				SELECT p.person_id, ilv.id AS 'episode_id'
				FROM @PERSONS ptt
				INNER JOIN video.persons p
				ON (p.first_name = ptt.first_name
					AND (p.middle_name = ptt.middle_name OR (p.middle_name IS NULL AND ptt.middle_name IS NULL))
					AND (p.last_name = ptt.last_name OR (p.last_name IS NULL AND ptt.last_name IS NULL))
					AND (p.suffix = ptt.suffix OR (p.suffix IS NULL AND ptt.suffix IS NULL)))
				INNER JOIN (SELECT id FROM #Episode WHERE category = 'TV_EPISODE_ID') ilv
					ON ilv.id IS NOT NULL
			) AS source
			ON target.person_id = source.person_id
				AND target.tv_episode_id = source.episode_id
			WHEN NOT MATCHED THEN
			INSERT (tv_episode_id, person_id)
				VALUES(source.episode_id, source.person_id);
			
		COMMIT TRANSACTION;

		SELECT tv_episode_id, series_id, episode_imdb_id, season_number, episode_number, episode_name, release_date, plot, resolution, codec,
			first_name, middle_name, last_name, suffix, person_role, genre_name, rating_source, rating_value, @is_updated AS 'updated'
		FROM video.vw_tv_episodes
		WHERE tv_episode_id IN (SELECT id FROM #Episode WHERE category = 'TV_EPISODE_ID');

		RETURN 0;
	END TRY
	BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE() + ':' + CONVERT(VARCHAR, ERROR_LINE()),
            @ErrorSeverity INT = ERROR_SEVERITY(),
            @ErrorState INT = ERROR_STATE();
		
        ROLLBACK TRANSACTION;
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END