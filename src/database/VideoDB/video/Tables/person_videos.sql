CREATE TABLE [video].[person_videos] (
    [person_id]   INT          NOT NULL,
    [video_id]    INT          NOT NULL,
    CONSTRAINT [pk_star_videos_star_id_video_id] PRIMARY KEY CLUSTERED ([person_id] ASC, [video_id] ASC),
    CONSTRAINT [fk_star_videos_star_id] FOREIGN KEY ([person_id]) REFERENCES [video].[persons] ([person_id]),
    CONSTRAINT [fk_star_videos_video_id] FOREIGN KEY ([video_id]) REFERENCES [video].[videos] ([video_id])
);

