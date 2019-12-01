CREATE VIEW [video].[vw_movies]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'movie_title', v.mpaa_rating AS 'movie_rating', v.runtime, v.plot, v.release_date, v.resolution, v.codec
			,g.name AS 'genre_name'
			,p.first_name, p.middle_name, p.last_name, p.suffix
			,roles.role_name AS 'person_role'
			,r.source AS 'rating_source', r.value AS 'rating_value'
		FROM video.videos v WITH (NOLOCK)
		JOIN video.ratings r WITH (NOLOCK)
			ON r.video_id = v.video_id
		JOIN video.genre_videos gv WITH (NOLOCK)
			ON gv.video_id = v.video_id
		JOIN video.person_videos pv WITH (NOLOCK)
			ON pv.video_id = v.video_id
		JOIN video.genres g WITH (NOLOCK)
			ON g.genre_id = gv.genre_id
		JOIN video.persons p WITH (NOLOCK)
			ON p.person_id = pv.person_id
		JOIN video.person_roles pr WITH (NOLOCK)
			ON pr.person_id = p.person_id
		JOIN video.roles roles WITH (NOLOCK)
			ON roles.role_id = pr.role_id
		WHERE v.video_type = 'movie';
