CREATE TABLE [video].[videos] (
    [video_id]     INT            IDENTITY (1, 1) NOT NULL,
    [video_type]   VARCHAR (8)    NOT NULL,
    [imdb_id]      VARCHAR (32)   NOT NULL,
    [title]        VARCHAR (512)   NOT NULL,
    [mpaa_rating]  VARCHAR (8)    NULL,
    [runtime]      DECIMAL (5, 2) NULL,
    [plot]         VARCHAR (MAX) NOT NULL,
    [release_date] DATETIME       NOT NULL,
    [added]        DATETIME       NULL,
    [modified]     DATETIME       NULL,
    [modified_by]  VARCHAR (64)   NULL,
    [created_by] VARCHAR(64) NULL, 
    CONSTRAINT [pk_videos_video_id] PRIMARY KEY CLUSTERED ([video_id] ASC)
);

