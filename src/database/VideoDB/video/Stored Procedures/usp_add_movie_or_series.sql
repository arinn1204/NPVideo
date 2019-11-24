CREATE PROCEDURE [video].[usp_add_movie_or_series] (
	@imdb_id VARCHAR(32),
    @title VARCHAR(64),
    @mpaa_rating VARCHAR(8),
    @runtime DECIMAL(5, 2) = NULL,
    @plot VARCHAR(MAX),
    @video_type VARCHAR(8),
    @release_date DATETIME,
    @resolution VARCHAR(16) = NULL,
    @codec VARCHAR(8) = NULL,
	@extended VARCHAR(16) = NULL,
    @GENRES genre_table_type READONLY,
    @PERSONS person_table_type READONLY,
    @RATINGS rating_table_type READONLY)
AS
BEGIN

	DECLARE @video_id INT,
		@created_time DATETIME = GETDATE(),
		@created_user VARCHAR = (SELECT SYSTEM_USER);
		

	BEGIN TRY

		CREATE TABLE #Video(
			id INT,
			name VARCHAR(16),
			category VARCHAR(32)
		);

		BEGIN TRANSACTION

			IF ((SELECT video_id
					FROM video.videos
					WHERE imdb_id = @imdb_id
						AND title = @title
						AND mpaa_rating = @mpaa_rating
						AND plot = @plot
						AND video_type = @video_type
						AND release_date = @release_date
						AND runtime = @runtime
						AND (resolution = @resolution OR resolution IS NULL AND @resolution IS NULL)
						AND (codec = @codec OR codec IS NULL AND @codec IS NULL)
						AND (extended_edition = @extended OR extended_edition IS NULL AND @extended IS NULL)) IS NOT NULL)
				BEGIN
					INSERT INTO #Video(id, category)
						SELECT video_id, 'VIDEO_ID'
						FROM video.videos
						WHERE imdb_id = @imdb_id
							AND title = @title
							AND mpaa_rating = @mpaa_rating
							AND plot = @plot
							AND video_type = @video_type
							AND release_date = @release_date
							AND runtime = @runtime
							AND (resolution = @resolution OR resolution IS NULL AND @resolution IS NULL)
							AND (codec = @codec OR codec IS NULL AND @codec IS NULL)
							AND (extended_edition = @extended OR extended_edition IS NULL AND @extended IS NULL);
				END
			ELSE
				BEGIN
					MERGE video.videos AS target
					USING (SELECT @imdb_id AS 'imdb_id',
								@title AS 'title',
								@mpaa_rating AS 'mpaa',
								@runtime AS 'runtime',
								@plot AS 'plot',
								@video_type AS 'video_type',
								@release_date AS 'release_date',
								@resolution AS 'resolution',
								@codec AS 'codec',
								@extended AS 'extended',
								@created_time AS 'ctime',
								@created_user AS 'cuser') AS source
					ON ((SELECT video_id
						FROM video.videos 
						WHERE imdb_id = @imdb_id) IS NOT NULL 
						AND (SELECT 1
							FROM video.videos
							WHERE imdb_id = @imdb_id
								AND title = @title
								AND mpaa_rating = @mpaa_rating
								AND plot = @plot
								AND video_type = @video_type
								AND release_date = @release_date) IS NULL)
					WHEN NOT MATCHED THEN
						INSERT (imdb_id, title, mpaa_rating, runtime, plot, video_type, release_date,
													resolution, codec, extended_edition, added, created_by)
							VALUES(source.imdb_id, source.title, source.mpaa, source.runtime, source.plot, source.video_type,
								source.release_date, source.resolution, source.codec, source.extended, source.ctime, source.cuser)
					WHEN MATCHED THEN
						UPDATE
							SET title = source.title,
								mpaa_rating = source.mpaa,
								plot = source.plot,
								video_type = source.video_type,
								release_date = source.release_date,
								runtime = source.runtime,
								resolution = source.resolution,
								codec = source.codec,
								extended_edition = source.extended,
								modified = source.ctime,
								modified_by = source.cuser
					OUTPUT INSERTED.video_id, 'VIDEO_ID'
						INTO #Video(id, category);
				END

			SET @video_id = (
				SELECT id 
				FROM #Video
				WHERE category = 'VIDEO_ID');

            MERGE INTO video.ratings AS target
			USING (SELECT DISTINCT r.source AS 'ratings_source', r.value AS 'ratings_value' FROM @RATINGS r) AS source
			ON target.video_id = @video_id
			WHEN NOT MATCHED THEN
				INSERT (video_id, source, value, added, created_by)
					VALUES(@video_id, source.ratings_source, source.ratings_value, @created_time, @created_user);

            MERGE INTO video.genres AS target
            USING (SELECT DISTINCT name FROM @GENRES) AS source
			ON target.name = source.name
            WHEN NOT MATCHED THEN
                INSERT (name, added, created_by)
                VALUES (source.name, @created_time, @created_user);

			INSERT INTO #Video(id, name, category)
				SELECT g.genre_id, g.name, 'GENRE_ID'
				FROM @GENRES genre
				JOIN video.genres g
					ON genre.name = g.name;

			MERGE INTO video.genre_videos AS target
			USING (SELECT id AS genre_id FROM #Video WHERE category = 'GENRE_ID') AS source
			ON target.genre_id = source.genre_id AND target.video_id = @video_id
			WHEN NOT MATCHED THEN
				INSERT (video_id, genre_id)
				VALUES (@video_id, source.genre_id);

			MERGE INTO video.roles AS target
			USING (SELECT DISTINCT role_name FROM @PERSONS) AS source
			ON source.role_name = target.role_name
			WHEN NOT MATCHED THEN
				INSERT (role_name, added, created_by)
				VALUES (source.role_name, @created_time, @created_user);

			INSERT INTO #Video(id, name, category)
				SELECT r.role_id, p.role_name, 'ROLE_ID'
				FROM video.roles r
				JOIN (SELECT DISTINCT role_name FROM @PERSONS) p
					ON r.role_name = p.role_name;

            MERGE INTO video.persons AS target
            USING (SELECT DISTINCT first_name, middle_name, last_name, suffix FROM @PERSONS) AS source
            ON (source.first_name = target.first_name
                AND
                (source.middle_name = target.middle_name OR (source.middle_name IS NULL AND target.middle_name IS NULL))
                AND (source.last_name = target.last_name OR (source.last_name IS NULL AND target.last_name IS NULL))
                AND (source.suffix = target.suffix OR (source.suffix IS NULL AND target.suffix IS NULL)))
            WHEN NOT MATCHED THEN
                INSERT (first_name, middle_name, last_name, suffix, added, created_by)
                VALUES (source.first_name, source.middle_name, source.last_name, source.suffix, @created_time, @created_user);

			INSERT INTO #Video(id, name, category)
				SELECT p.person_id, persons_tt.role_name, 'PERSON_ID'
				FROM @PERSONS persons_tt
				JOIN video.persons p
					ON (p.first_name = persons_tt.first_name
					AND (p.middle_name = persons_tt.middle_name OR (p.middle_name IS NULL AND persons_tt.middle_name IS NULL))
					AND (p.last_name = persons_tt.last_name OR (p.last_name IS NULL AND persons_tt.last_name IS NULL))
					AND (p.suffix = persons_tt.suffix OR (p.suffix IS NULL AND persons_tt.suffix IS NULL)))


			MERGE INTO video.person_roles AS target
			USING (SELECT DISTINCT person.id AS 'person_id', role.id AS 'role_id'
				FROM @PERSONS p
				JOIN #Video person
					ON person.name = p.role_name
					AND person.category = 'PERSON_ID'
				JOIN #Video role
					ON role.name = p.role_name
					AND role.category = 'ROLE_ID') AS source
			ON target.person_id = source.person_id
				AND target.role_id = source.role_id
			WHEN NOT MATCHED THEN
				INSERT (person_id, role_id)
					VALUES(source.person_id, source.role_id);

					
			MERGE INTO video.person_videos AS target
			USING (SELECT DISTINCT id FROM #Video WHERE category = 'PERSON_ID') AS source
			ON target.person_id = source.id
				AND target.video_id = @video_id
			WHEN NOT MATCHED THEN
			INSERT (video_id, person_id)
				VALUES(@video_id, source.id);

			
		COMMIT TRANSACTION;

		SELECT imdb_id, movie_title, movie_rating, runtime, plot, release_date, resolution, codec,
			genre_name, first_name, middle_name, last_name, suffix, person_role, rating_source, rating_value
		FROM video.vw_movies
		WHERE video_id = @video_id;

		RETURN @video_id;

	END TRY
	BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE() + ':' + CONVERT(VARCHAR, ERROR_LINE()),
            @ErrorSeverity INT = ERROR_SEVERITY(),
            @ErrorState INT = ERROR_STATE();
		
        ROLLBACK TRANSACTION;
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END