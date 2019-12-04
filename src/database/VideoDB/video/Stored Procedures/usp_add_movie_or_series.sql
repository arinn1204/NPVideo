CREATE PROCEDURE [video].[usp_add_movie_or_series] (
	@imdb_id VARCHAR(32),
    @title VARCHAR(512),
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

	DECLARE @created_time DATETIME = GETDATE(),
		@created_user VARCHAR(32) = (SELECT SYSTEM_USER),
		@is_updated BIT = 0,
		@video_id INT;
		
		
	BEGIN TRY

		CREATE TABLE #Video(
			id INT,
			name VARCHAR(16),
			category VARCHAR(32)
		);

		CREATE TABLE #roles(
			role_name VARCHAR(16)
		);


		BEGIN TRANSACTION
			
			IF (@imdb_id IS NULL) RAISERROR('@imdb_id is a required parameter.', 16, 1);
			IF (@plot IS NULL) RAISERROR('@plot is a required parameter.', 16, 1);
			IF (@release_date IS NULL) RAISERROR ('@release_date is a required parameter.', 16, 1);
			IF (@title IS NULL) RAISERROR ('@title is a required parameter.', 16, 1);
			IF (@video_type IS NULL) RAISERROR ('@video_type is a required parameter.', 16, 1);
			IF (@video_type = 'movie')
			BEGIN
				IF (@mpaa_rating IS NULL) RAISERROR('@mpaa_rating is a required parameter for video_type = movie.', 16, 1);
				IF (@runtime IS NULL) RAISERROR('@runtime is a required parameter for video_type = movie.', 16, 1);
				IF (@codec IS NULL) RAISERROR('@codec is a required parameter for video_type = movie.', 16, 1);
				IF (@resolution IS NULL) RAISERROR('@resolution is a required parameter for video_type = movie.', 16, 1);
			END


			IF NOT EXISTS (SELECT video_id
					FROM video.videos
					WHERE imdb_id = @imdb_id
						AND title = @title
						AND plot = @plot
						AND video_type = @video_type
						AND release_date = @release_date
						AND ((mpaa_rating = @mpaa_rating) OR mpaa_rating IS NULL AND @mpaa_rating IS NULL)
						AND ((runtime = @runtime) OR (runtime IS NULL AND @runtime IS NULL)))
				BEGIN
					MERGE video.videos AS target
					USING (SELECT @imdb_id AS 'imdb_id',
								@title AS 'title',
								@mpaa_rating AS 'mpaa',
								@runtime AS 'runtime',
								@plot AS 'plot',
								@video_type AS 'video_type',
								@release_date AS 'release_date',
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
													 added, created_by)
							VALUES(source.imdb_id, source.title, source.mpaa, source.runtime, source.plot, source.video_type,
								source.release_date, source.ctime, source.cuser)
					WHEN MATCHED THEN
						UPDATE
							SET title = source.title,
								mpaa_rating = source.mpaa,
								plot = source.plot,
								video_type = source.video_type,
								release_date = source.release_date,
								runtime = source.runtime,
								modified = source.ctime,
								modified_by = source.cuser,
								@is_updated = 1
					OUTPUT INSERTED.video_id, 'INSERTED_ID'
						INTO #Video(id, category);
						
				END

			SELECT @video_id = id
			FROM #Video
			WHERE category = 'INSERTED_ID'

			IF (@video_id IS NULL)
			BEGIN
				SELECT @video_id = video_id
				FROM video.videos
				WHERE imdb_id = @imdb_id;
			END

			INSERT INTO #roles(role_name)
				SELECT DISTINCT role_name 
				FROM @PERSONS;


			MERGE INTO video.video_metadata AS target
			USING (
				SELECT @resolution AS 'resolution', @codec AS 'codec', @extended AS 'extended'
			) AS source
			ON target.resolution = source.resolution
				AND target.codec = source.codec
				AND ((target.extended_format = source.extended) OR (target.extended_format IS NULL AND source.extended IS NULL))
			WHEN NOT MATCHED AND @video_type = 'movie'
			THEN
				INSERT (video_id, resolution, codec, extended_format)
					VALUES (@video_id, source.resolution, source.codec, source.extended);

            MERGE INTO video.ratings AS target
			USING (
				SELECT r.source AS 'ratings_source', r.value AS 'ratings_value'
				FROM @RATINGS r
				) AS source
			ON target.video_id = @video_id
			WHEN NOT MATCHED THEN
				INSERT (video_id, source, value, added, created_by)
					VALUES(@video_id, source.ratings_source, source.ratings_value, @created_time, @created_user);

            MERGE INTO video.genres AS target
            USING (
				SELECT name
				FROM @GENRES
				) AS source
			ON target.name = source.name
            WHEN NOT MATCHED THEN
                INSERT (name, added, created_by)
                VALUES (source.name, @created_time, @created_user);

			INSERT INTO #Video(id, name, category)
				SELECT g.genre_id, g.name, 'GENRE_ID'
				FROM @GENRES genre
				INNER JOIN video.genres g
					ON genre.name = g.name;

			MERGE INTO video.roles AS target
			USING (SELECT role_name FROM #roles) AS source
			ON source.role_name = target.role_name
			WHEN NOT MATCHED THEN
				INSERT (role_name, added, created_by)
				VALUES (source.role_name, @created_time, @created_user);

			INSERT INTO #Video(id, name, category)
				SELECT r.role_id, p.role_name, 'ROLE_ID'
				FROM video.roles r
				INNER JOIN (SELECT role_name FROM #roles) p
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
				INNER JOIN video.persons p
					ON (p.first_name = persons_tt.first_name
					AND (p.middle_name = persons_tt.middle_name OR (p.middle_name IS NULL AND persons_tt.middle_name IS NULL))
					AND (p.last_name = persons_tt.last_name OR (p.last_name IS NULL AND persons_tt.last_name IS NULL))
					AND (p.suffix = persons_tt.suffix OR (p.suffix IS NULL AND persons_tt.suffix IS NULL)))


			MERGE INTO video.person_roles AS target
			USING (SELECT DISTINCT person.id AS 'person_id', role.id AS 'role_id'
				FROM @PERSONS p
				INNER JOIN #Video person
					ON person.name = p.role_name
					AND person.category = 'PERSON_ID'
				INNER JOIN #Video role
					ON role.name = p.role_name
					AND role.category = 'ROLE_ID') AS source
			ON target.person_id = source.person_id
				AND target.role_id = source.role_id
			WHEN NOT MATCHED THEN
				INSERT (person_id, role_id)
					VALUES(source.person_id, source.role_id);
					
			MERGE INTO video.person_videos AS target
			USING (
				SELECT DISTINCT v.id AS 'person_id'
				FROM #Video v
				WHERE category = 'PERSON_ID'
			) AS source
			ON target.person_id = source.person_id
				AND target.video_id = @video_id
			WHEN NOT MATCHED THEN
			INSERT (video_id, person_id)
				VALUES(@video_id, source.person_id);


			MERGE INTO video.genre_videos AS target
			USING (
				SELECT DISTINCT v.id AS 'genre_id'
				FROM #Video v
				WHERE category = 'GENRE_ID'
				) AS source
			ON 
				target.genre_id = source.genre_id 
				AND target.video_id = @video_id
			WHEN NOT MATCHED THEN
				INSERT (video_id, genre_id)
				VALUES (@video_id, source.genre_id);



			IF (@video_type = 'movie')
			BEGIN
				SELECT video_id, imdb_id, title AS 'movie_title', mpaa_rating AS 'movie_rating', runtime, plot, release_date, @is_updated AS 'updated'
				FROM video.videos
				WHERE video_id = @video_id;
			END
			ELSE 
			BEGIN
				IF (@video_type = 'series')
				BEGIN
					SELECT video_id, imdb_id, title, plot, release_date, @is_updated AS 'updated'
					FROM video.videos
					WHERE video_id = @video_id;
				END
						
			END

			
		COMMIT TRANSACTION;

		
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