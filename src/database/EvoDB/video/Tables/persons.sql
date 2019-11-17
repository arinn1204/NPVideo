CREATE TABLE [video].[persons] (
    [person_id]   INT          IDENTITY (1, 1) NOT NULL,
    [first_name]  VARCHAR (64) NOT NULL,
    [middle_name] VARCHAR (64) NULL,
    [last_name]   VARCHAR (64) NULL,
    [suffix]      VARCHAR (64) NULL,
    [added]       DATETIME     NULL,
    [modified]    DATETIME     NULL,
    [modified_by] VARCHAR (32) NULL,
    [created_by] VARCHAR(32) NULL, 
    CONSTRAINT [pk_stars_star_id] PRIMARY KEY CLUSTERED ([person_id] ASC)
);

