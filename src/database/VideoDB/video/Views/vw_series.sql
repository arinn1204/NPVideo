CREATE VIEW [video].[vw_series]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'title', v.plot, v.release_date
			,g.name AS 'genre_name'
			,p.first_name, p.middle_name, p.last_name, p.suffix
			,roles.role_name AS 'person_role'
			,ilv.value AS 'rating_value', ilv.source AS 'rating_source'
		FROM video.videos v WITH (NOLOCK)
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
		JOIN (SELECT video_id, source, AVG(value) AS 'value'
				FROM video.ratings WITH (NOLOCK)
				WHERE tv_episode_id IS NULL
				GROUP BY video_id, source, value) ilv 
			ON ilv.video_id = v.video_id
	WHERE v.video_type = 'series';