CREATE VIEW [video].[vw_tv_episodes]
	AS 
		SELECT tv.tv_episode_id, tv.tv_episode_imdb_id AS 'episode_imdb_id', tv.season_number, tv.episode_number, tv.episode_name, tv.release_date, tv.plot, tv.resolution, tv.codec,
			p.first_name, p.middle_name, p.last_name, p.suffix, role.role_name AS 'person_role', g.name AS 'genre_name', r.source AS 'rating_source', r.value AS 'rating_value'
		FROM video.tv_episodes tv
		JOIN video.ratings r
			ON tv.tv_episode_id = r.tv_episode_id
		JOIN video.genre_tv_episodes gte
			ON gte.tv_episode_id = tv.tv_episode_id
		JOIN video.genres g
			ON g.genre_id = gte.genre_id
		JOIN video.person_tv_episodes pte
			ON pte.tv_episode_id = tv.tv_episode_id
		JOIN video.persons p
			ON p.person_id = pte.person_id
		JOIN video.person_roles pr
			ON pr.person_id = p.person_id
		JOIN video.roles role
			ON role.role_id = pr.role_id;

