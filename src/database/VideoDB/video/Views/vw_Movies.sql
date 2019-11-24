CREATE VIEW [video].[vw_movies]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'movie_title', v.mpaa_rating AS 'movie_rating', v.runtime, v.plot, v.release_date, v.resolution, v.codec
			,g.name AS 'genre_name'
			,p.first_name, p.middle_name, p.last_name, p.suffix
			,roles.role_name AS 'person_role'
			,r.source AS 'rating_source', r.value AS 'rating_value'
		FROM video.videos v
			WITH (NOLOCK)
		JOIN video.ratings r
			ON r.video_id = v.video_id
		JOIN video.genre_videos gv
			ON gv.video_id = v.video_id
		JOIN video.person_videos pv
			ON pv.video_id = v.video_id
		JOIN video.genres g
			ON g.genre_id = gv.genre_id
		JOIN video.persons p
			ON p.person_id = pv.person_id
		JOIN video.person_roles pr
			ON pr.person_id = p.person_id
		JOIN video.roles roles
			ON roles.role_id = pr.role_id
		WHERE v.video_type = 'movie';
