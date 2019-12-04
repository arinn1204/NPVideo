CREATE VIEW [video].[vw_tv_series]
	AS 
	SELECT v.video_id, v.imdb_id, v.title, v.plot, v.release_date
		FROM video.videos v WITH (NOLOCK)
	WHERE v.video_type = 'series';