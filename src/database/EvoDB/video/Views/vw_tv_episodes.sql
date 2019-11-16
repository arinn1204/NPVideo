CREATE VIEW [evo].[vw_tv_episodes]
	AS 
		SELECT tv.tv_episode_id, tv.tv_episode_imdb_id AS 'episode_imdb_id', tv.season_number, tv.episode_number, tv.episode_name, tv.release_date, tv.plot, tv.resolution, tv.codec,
			p.first_name, p.middle_name, p.last_name, p.suffix, role.role_name AS 'person_role', g.name AS 'genre_name', r.source AS 'rating_source', r.value AS 'rating_value'
		FROM evo.tv_episodes tv
		JOIN evo.ratings r
			ON tv.tv_episode_id = r.tv_episode_id
		JOIN evo.genre_tv_episodes gte
			ON gte.tv_episode_id = tv.tv_episode_id
		JOIN evo.genres g
			ON g.genre_id = gte.genre_id
		JOIN evo.person_tv_episodes pte
			ON pte.tv_episode_id = tv.tv_episode_id
		JOIN evo.persons p
			ON p.person_id = pte.person_id
		JOIN evo.person_roles pr
			ON pr.person_id = p.person_id
		JOIN evo.roles role
			ON role.role_id = pr.role_id;

