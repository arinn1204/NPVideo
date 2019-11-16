CREATE TABLE [evo].[ratings] (
    [rating_id]   INT            IDENTITY (1, 1) NOT NULL,
    [video_id]    INT            NOT NULL,
    [tv_episode_id]    INT            NULL,
    [source]      VARCHAR (32)   NOT NULL,
    [value]       DECIMAL (5, 2) NOT NULL,
    [added]       DATETIME       NULL,
    [modified]    DATETIME       NULL,
    [modified_by] VARCHAR (32)   NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_ratings_rating_id] PRIMARY KEY CLUSTERED ([rating_id] ASC),
    CONSTRAINT [fk_ratings_video_id] FOREIGN KEY ([video_id]) REFERENCES [evo].[videos] ([video_id]),
	CONSTRAINT [fk_ratings_tv_episode_id] FOREIGN KEY ([tv_episode_id]) REFERENCES [evo].[tv_episodes] ([tv_episode_id])
);

