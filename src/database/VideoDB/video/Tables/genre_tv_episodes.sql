CREATE TABLE [video].[genre_tv_episodes] (
    [genre_id]    INT          NOT NULL,
    [tv_episode_id]    INT          NOT NULL,
    CONSTRAINT [pk_genre_tv_episodes_genre_id_tv_episode_id] PRIMARY KEY CLUSTERED ([genre_id] ASC, [tv_episode_id] ASC),
    CONSTRAINT [fk_genre_tv_episodes_genre_id] FOREIGN KEY ([genre_id]) REFERENCES [video].[genres] ([genre_id]),
    CONSTRAINT [fk_genre_tv_episodes_tv_episode_id] FOREIGN KEY ([tv_episode_id]) REFERENCES [video].[tv_episodes] ([tv_episode_id])
);

