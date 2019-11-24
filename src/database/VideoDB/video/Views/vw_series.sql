CREATE VIEW [video].[vw_series]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'title', v.plot, v.release_date
			,g.name AS 'genre_name'
			,p.first_name, p.middle_name, p.last_name, p.suffix
			,roles.role_name AS 'person_role'
			,r.source AS 'rating_source', 
			(SELECT AVG(r1.value) 
				FROM video.ratings r1 
				WHERE r1.source = r.source
				GROUP BY r1.source) AS 'rating_value'
		FROM video.videos v
			WITH (NOLOCK)
		JOIN video.ratings r
			ON r.video_id = v.video_id
				AND r.tv_episode_id IS NULL
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
	WHERE v.video_type = 'series';