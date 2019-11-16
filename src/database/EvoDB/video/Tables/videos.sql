CREATE TABLE [evo].[videos] (
    [video_id]     INT            IDENTITY (1, 1) NOT NULL,
    [imdb_id]      VARCHAR (32)   NOT NULL,
    [title]        VARCHAR (64)   NOT NULL,
    [mpaa_rating]  VARCHAR (8)    NOT NULL,
    [runtime]      DECIMAL (5, 2) NULL,
    [plot]         VARCHAR (MAX) NOT NULL,
    [video_type]   VARCHAR (8)    NOT NULL,
    [release_date] DATETIME       NOT NULL,
    [resolution]   VARCHAR (16)   NULL,
    [codec]        VARCHAR (8)    NULL,
    [extended_edition] VARCHAR(16) NULL, 
    [added]        DATETIME       NULL,
    [modified]     DATETIME       NULL,
    [modified_by]  VARCHAR (32)   NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_videos_video_id] PRIMARY KEY CLUSTERED ([video_id] ASC)
);

