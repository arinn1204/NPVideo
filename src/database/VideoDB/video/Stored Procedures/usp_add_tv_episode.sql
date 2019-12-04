CREATE PROCEDURE [video].[usp_add_tv_episode] (
	@series_imdb_id VARCHAR(32),
    @series_title VARCHAR(512),
    @mpaa_rating VARCHAR(8),
	@series_plot VARCHAR(MAX),
	@series_release_date DATETIME,
	@episode_imdb_id VARCHAR(32),
    @runtime DECIMAL(5, 2),
    @episode_release_date DATETIME,
	@season_number INT,
	@episode_number INT,
	@episode_name VARCHAR(512),
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

			IF (@episode_imdb_id IS NULL) RAISERROR('@episode_imdb_id is a required parameter.', 16, 1);
			IF (@series_imdb_id IS NULL) RAISERROR('@series_imdb_id is a required parameter.', 16, 1);
			IF (@series_title IS NULL) RAISERROR('@series_title is a required parameter.', 16, 1);
			IF (@mpaa_rating IS NULL) RAISERROR('@mpaa_rating is a required parameter.', 16, 1);
			IF (@series_plot IS NULL) RAISERROR('@series_plot is a required parameter.', 16, 1);
			IF (@series_release_date IS NULL) RAISERROR('@series_release_date is a required parameter.', 16, 1);
			IF (@runtime IS NULL) RAISERROR('@runtime is a required parameter.', 16, 1);
			IF (@episode_release_date IS NULL) RAISERROR('@episode_release_date is a required parameter.', 16, 1);
			IF (@season_number IS NULL) RAISERROR('@season_number is a required parameter.', 16, 1);
			IF (@episode_number IS NULL) RAISERROR('@episode_number is a required parameter.', 16, 1);
			IF (@episode_name IS NULL) RAISERROR('@episode_name is a required parameter.', 16, 1);
			IF (@plot IS NULL) RAISERROR('@plot is a required parameter.', 16, 1);
			IF (@codec IS NULL) RAISERROR('@codec is a required parameter.', 16, 1);
			IF (@resolution IS NULL) RAISERROR('@resolution is a required parameter.', 16, 1);

			DECLARE @series_video_id INT,
				@episode_id INT,
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
				null,
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
					AND plot = @series_plot
					AND release_date = @series_release_date;

			IF NOT EXISTS (SELECT 1
				FROM video.tv_episodes
				WHERE series_id = @series_video_id
					AND imdb_id = @episode_imdb_id
					AND season_number = @season_number
					AND episode_number = @episode_number
					AND episode_name = @episode_name
					AND release_date = @episode_release_date
					AND mpaa_rating = @mpaa_rating
					AND runtime = @runtime
					AND plot = @plot)
				BEGIN
					MERGE video.tv_episodes AS target
					USING (SELECT @series_video_id AS 'video_id', 
								@episode_imdb_id AS 'imdb_id', 
								@season_number AS 'season_number', 
								@episode_number AS 'episode_number',
								@episode_name AS 'name', 
								@episode_release_date AS 'release_date',
								@plot AS 'plot',
								@runtime AS 'runtime',
								@mpaa_rating AS 'rating',
								@created_time AS 'ctime',
								@created_user AS 'cuser') AS source
					ON ((SELECT 1 
							FROM video.tv_episodes 
							WHERE imdb_id = source.imdb_id
								AND series_id = source.video_id) IS NOT NULL)
					WHEN NOT MATCHED THEN
						INSERT (series_id, imdb_id, mpaa_rating, season_number, episode_number, episode_name, release_date, plot, added, created_by, runtime)
							VALUES(source.video_id, source.imdb_id, source.rating, source.season_number, source.episode_number, source.name, source.release_date, source.plot, source.ctime, source.cuser, source.runtime)
					WHEN MATCHED THEN
						UPDATE 
							SET season_number = source.season_number,
								episode_number = source.episode_number,
								episode_name = source.name,
								release_date = source.release_date,
								plot = source.plot,
								mpaa_rating = source.rating,
								modified = source.ctime,
								modified_by = source.cuser,
								runtime = source.runtime,
								@is_updated = 1
					OUTPUT INSERTED.tv_episode_id, 'TV_EPISODE_ID'
						INTO #Episode(id, category);
				END

			SELECT @episode_id = id
			FROM #Episode
			WHERE category = 'TV_EPISODE_ID';

			IF (@episode_id IS NULL)
			BEGIN
				SELECT @episode_id = tv_episode_id
				FROM video.tv_episodes
				WHERE imdb_id = @episode_imdb_id;
			END

			
			MERGE INTO video.episode_metadata AS target
			USING (
				SELECT @resolution AS 'resolution', @codec AS 'codec', @extended AS 'extended'
			) AS source
			ON target.resolution = source.resolution
				AND target.codec = source.codec
				AND ((target.extended_format = source.extended) OR (target.extended_format IS NULL AND source.extended IS NULL))
			WHEN NOT MATCHED
			THEN
				INSERT (episode_id, resolution, codec, extended_format)
					VALUES (@episode_id, source.resolution, source.codec, source.extended);


            MERGE INTO video.ratings AS target
			USING (
				SELECT r.source AS 'ratings_source', r.value AS 'ratings_value'
				FROM @RATINGS r
			) AS source
			ON target.video_id = @series_video_id
				AND target.tv_episode_id = @episode_id
			WHEN NOT MATCHED THEN
				INSERT (video_id, tv_episode_id, source, value, added, created_by)
					VALUES(@series_video_id, @episode_id, source.ratings_source, source.ratings_value, @created_time, @created_user);

		
			MERGE INTO video.genre_tv_episodes AS target
			USING (
				SELECT g.genre_id
				FROM video.genres g
				INNER JOIN @GENRES gtt
					ON gtt.name = g.name
			) AS source
			ON target.genre_id = source.genre_id 
				AND target.tv_episode_id = @episode_id
			WHEN NOT MATCHED THEN
				INSERT (tv_episode_id, genre_id)
				VALUES (@episode_id, source.genre_id);

			
			MERGE INTO video.person_tv_episodes AS target
			USING (
				SELECT p.person_id
				FROM @PERSONS ptt
				INNER JOIN video.persons p
				ON (p.first_name = ptt.first_name
					AND (p.middle_name = ptt.middle_name OR (p.middle_name IS NULL AND ptt.middle_name IS NULL))
					AND (p.last_name = ptt.last_name OR (p.last_name IS NULL AND ptt.last_name IS NULL))
					AND (p.suffix = ptt.suffix OR (p.suffix IS NULL AND ptt.suffix IS NULL)))
			) AS source
			ON target.person_id = source.person_id
				AND target.tv_episode_id = @episode_id
			WHEN NOT MATCHED THEN
			INSERT (tv_episode_id, person_id)
				VALUES(@episode_id, source.person_id);
			
		COMMIT TRANSACTION;

		SELECT tv_episode_id, series_id, imdb_id, season_number, episode_number, episode_name, release_date, plot, runtime, @is_updated AS 'updated'
		FROM video.tv_episodes
		WHERE tv_episode_id = @episode_id;

		RETURN 0;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();

		IF (@ErrorMessage NOT LIKE ('% is a required parameter%'))
			SET @ErrorMessage = @ErrorMessage + ':' + CONVERT(VARCHAR, ERROR_LINE());
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY(),
            @ErrorState INT = ERROR_STATE();
		
        ROLLBACK TRANSACTION;
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END