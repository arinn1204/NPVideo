CREATE VIEW [video].[vw_tv_series]
	AS 
	SELECT v.video_id, v.imdb_id, v.title, v.plot, v.release_date, rating_view.mpaa_rating
		FROM video.videos v WITH (NOLOCK)
		INNER JOIN (
			SELECT TOP(1) series_id, mpaa_rating, COUNT(mpaa_rating) AS rating_count
				FROM video.tv_episodes
				GROUP BY series_id, mpaa_rating, mpaa_rating
				ORDER BY rating_count DESC
		) rating_view
			ON rating_view.series_id = v.video_id
	WHERE v.video_type = 'series';