CREATE VIEW [video].[vw_tv_episodes]
	AS 
		SELECT tv.tv_episode_id, tv.tv_episode_imdb_id AS 'episode_imdb_id', tv.season_number, tv.episode_number, tv.episode_name, tv.release_date, tv.plot, tv.resolution, tv.codec,
			p.first_name, p.middle_name, p.last_name, p.suffix, role.role_name AS 'person_role', g.name AS 'genre_name', r.source AS 'rating_source', r.value AS 'rating_value'
		FROM video.tv_episodes tv WITH (NOLOCK)
		INNER JOIN video.ratings r WITH (NOLOCK)
			ON tv.tv_episode_id = r.tv_episode_id
		INNER JOIN video.genre_tv_episodes gte WITH (NOLOCK)
			ON gte.tv_episode_id = tv.tv_episode_id
		INNER JOIN video.genres g WITH (NOLOCK)
			ON g.genre_id = gte.genre_id
		INNER JOIN video.person_tv_episodes pte WITH (NOLOCK)
			ON pte.tv_episode_id = tv.tv_episode_id
		INNER JOIN video.persons p WITH (NOLOCK)
			ON p.person_id = pte.person_id
		INNER JOIN video.person_roles pr WITH (NOLOCK)
			ON pr.person_id = p.person_id
		INNER JOIN video.roles role WITH (NOLOCK)
			ON role.role_id = pr.role_id;

