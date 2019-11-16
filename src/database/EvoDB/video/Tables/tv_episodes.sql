CREATE TABLE [evo].[tv_episodes] (
    [tv_episode_id]      INT            IDENTITY (1, 1) NOT NULL,
    [video_id]           INT            NOT NULL,
    [tv_episode_imdb_id] VARCHAR (32)   NOT NULL,
    [season_number]      INT            NOT NULL,
    [episode_number]     INT            NOT NULL,
    [episode_name]       VARCHAR (64)   NOT NULL,
    [release_date]       DATETIME       NOT NULL,
    [plot]               VARCHAR (MAX) NOT NULL,
    [resolution]         VARCHAR (16)   NULL,
    [codec]              VARCHAR (8)    NULL,
    [extended_edition] VARCHAR(16) NULL, 
    [added]              DATETIME       NULL,
    [modified]           DATETIME       NULL,
    [modified_by]        VARCHAR (32)   NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_tv_episodes_tv_episode_id] PRIMARY KEY CLUSTERED ([tv_episode_id] ASC),
    CONSTRAINT [fk_tv_episodes_video_id] FOREIGN KEY ([video_id]) REFERENCES [evo].[videos] ([video_id])
);

