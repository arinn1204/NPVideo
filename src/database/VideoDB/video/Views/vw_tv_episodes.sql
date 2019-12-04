CREATE VIEW [video].[vw_tv_episodes]
	AS 
	SELECT tv.tv_episode_id, tv.series_id, tv.imdb_id, tv.mpaa_rating,
		tv.season_number, tv.episode_number, tv.episode_name, tv.release_date, tv.plot, tv.runtime
	FROM video.tv_episodes tv WITH (NOLOCK);
