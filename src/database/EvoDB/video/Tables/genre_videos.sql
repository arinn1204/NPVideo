CREATE TABLE [evo].[genre_videos] (
    [genre_id]    INT          NOT NULL,
    [video_id]    INT          NOT NULL,
    CONSTRAINT [pk_genre_videos_genre_id_video_id] PRIMARY KEY CLUSTERED ([genre_id] ASC, [video_id] ASC),
    CONSTRAINT [fk_genre_videos_genre_id] FOREIGN KEY ([genre_id]) REFERENCES [evo].[genres] ([genre_id]),
    CONSTRAINT [fk_genre_videos_video_id] FOREIGN KEY ([video_id]) REFERENCES [evo].[videos] ([video_id])
);

