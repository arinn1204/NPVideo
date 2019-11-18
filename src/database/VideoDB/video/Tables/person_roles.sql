CREATE TABLE [video].[person_roles] (
    [role_id]    INT          NOT NULL,
    [person_id]  INT          NOT NULL,
    CONSTRAINT [pk_person_role_role_id_person_id] PRIMARY KEY CLUSTERED ([role_id] ASC, [person_id] ASC),
    CONSTRAINT [fk_video_person_role_persons_person_id] FOREIGN KEY ([person_id]) REFERENCES [video].[persons] ([person_id]),
    CONSTRAINT [fk_video_person_role_roles_role_id] FOREIGN KEY ([role_id]) REFERENCES [video].[roles] ([role_id])
);