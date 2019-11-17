CREATE TABLE [video].[person_tv_episodes] (
    [person_id]   INT          NOT NULL,
    [tv_episode_id]    INT          NOT NULL,
    CONSTRAINT [pk_star_tv_episodes_star_id_tv_episode_id] PRIMARY KEY CLUSTERED ([person_id] ASC, [tv_episode_id] ASC),
    CONSTRAINT [fk_star_tv_episodes_star_id] FOREIGN KEY ([person_id]) REFERENCES [video].[persons] ([person_id]),
    CONSTRAINT [fk_star_tv_episodes_tv_episode_id] FOREIGN KEY ([tv_episode_id]) REFERENCES [video].[tv_episodes] ([tv_episode_id])
);

