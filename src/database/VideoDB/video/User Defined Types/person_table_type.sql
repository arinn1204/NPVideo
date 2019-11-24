CREATE TYPE [video].[person_table_type] AS TABLE (
    [first_name]  VARCHAR (64) NOT NULL,
    [middle_name] VARCHAR (64) NULL,
    [last_name]   VARCHAR (64) NULL,
    [suffix]      VARCHAR (64) NULL,
    [role_name]   VARCHAR (16) NOT NULL);

