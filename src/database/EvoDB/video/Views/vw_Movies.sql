CREATE VIEW [evo].[vw_movies]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'movie_title', v.mpaa_rating AS 'movie_rating', v.runtime, v.plot, v.release_date, v.resolution, v.codec
			,g.name AS 'genre_name'
			,p.first_name, p.middle_name, p.last_name, p.suffix
			,roles.role_name AS 'person_role'
			,r.source AS 'rating_source', r.value AS 'rating_value'
		FROM evo.videos v
		JOIN evo.ratings r
			ON r.video_id = v.video_id
		JOIN evo.genre_videos gv
			ON gv.video_id = v.video_id
		JOIN evo.person_videos pv
			ON pv.video_id = v.video_id
		JOIN evo.genres g
			ON g.genre_id = gv.genre_id
		JOIN evo.persons p
			ON p.person_id = pv.person_id
		JOIN evo.person_roles pr
			ON pr.person_id = p.person_id
		JOIN evo.roles roles
			ON roles.role_id = pr.role_id
		WHERE v.video_type = 'movie';
