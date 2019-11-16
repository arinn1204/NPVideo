CREATE TABLE [evo].[person_videos] (
    [person_id]   INT          NOT NULL,
    [video_id]    INT          NOT NULL,
    CONSTRAINT [pk_star_videos_star_id_video_id] PRIMARY KEY CLUSTERED ([person_id] ASC, [video_id] ASC),
    CONSTRAINT [fk_star_videos_star_id] FOREIGN KEY ([person_id]) REFERENCES [evo].[persons] ([person_id]),
    CONSTRAINT [fk_star_videos_video_id] FOREIGN KEY ([video_id]) REFERENCES [evo].[videos] ([video_id])
);

