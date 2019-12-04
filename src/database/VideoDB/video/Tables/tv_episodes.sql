CREATE TABLE [video].[tv_episodes] (
    [tv_episode_id]      INT            IDENTITY (1, 1) NOT NULL,
    [series_id]           INT            NOT NULL,
    [imdb_id] VARCHAR (32)   NOT NULL,
    [season_number]      INT            NOT NULL,
    [episode_number]     INT            NOT NULL,
    [episode_name]       VARCHAR (512)   NOT NULL,
    [release_date]       DATETIME       NOT NULL,
    [mpaa_rating]  VARCHAR (8)    NOT NULL ,
    [plot]               VARCHAR (MAX) NOT NULL,
    [added]              DATETIME       NULL,
    [modified]           DATETIME       NULL,
    [modified_by]        VARCHAR (32)   NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_tv_episodes_tv_episode_id] PRIMARY KEY CLUSTERED ([tv_episode_id] ASC),
    CONSTRAINT [fk_tv_episodes_video_id] FOREIGN KEY ([series_id]) REFERENCES [video].[videos] ([video_id])
);

