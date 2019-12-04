CREATE TABLE [video].[episode_metadata]
(
	[metadata_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [episode_id] INT NOT NULL, 
    [resolution] NVARCHAR(16) NOT NULL, 
    [codec] NVARCHAR(8) NOT NULL, 
    [extended_format] NVARCHAR(32) NULL
	
    CONSTRAINT [fk_video_metadata_episode_id] FOREIGN KEY ([episode_id]) REFERENCES [video].[tv_episodes] ([tv_episode_id])
)
