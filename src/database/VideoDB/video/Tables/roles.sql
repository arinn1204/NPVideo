﻿CREATE TABLE [video].[roles] (
    [role_id]     INT          IDENTITY (1, 1) NOT NULL,
    [role_name]        VARCHAR (16) NOT NULL,
    [added]       DATETIME     NULL,
    [modified]    DATETIME     NULL,
    [modified_by] VARCHAR (64) NULL,
    [created_by] VARCHAR(64) NULL, 
    CONSTRAINT [pk_roles_role_id] PRIMARY KEY CLUSTERED ([role_id] ASC)
);

