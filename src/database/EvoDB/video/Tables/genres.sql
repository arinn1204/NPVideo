CREATE TABLE [video].[genres] (
    [genre_id]    INT          IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (32) NULL,
    [added]       DATETIME     NULL,
    [modified]    DATETIME     NULL,
    [modified_by] VARCHAR (32) NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_genres_genre_id] PRIMARY KEY CLUSTERED ([genre_id] ASC)
);

