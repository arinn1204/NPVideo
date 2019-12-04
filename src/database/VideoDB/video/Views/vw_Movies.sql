CREATE VIEW [video].[vw_movies]
	AS 
	SELECT v.video_id, v.imdb_id, v.title AS 'movie_title', v.mpaa_rating AS 'movie_rating',
		v.runtime, v.plot, v.release_date
	FROM video.videos v WITH (NOLOCK)
	WHERE v.video_type = 'movie';
