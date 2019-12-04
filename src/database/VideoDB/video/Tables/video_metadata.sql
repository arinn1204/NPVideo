CREATE TABLE [video].[video_metadata]
(
	[metadata_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [video_id] INT NOT NULL, 
    [resolution] NVARCHAR(16) NOT NULL, 
    [codec] NVARCHAR(8) NOT NULL, 
    [extended_format] NVARCHAR(32) NULL
	
    CONSTRAINT [fk_video_metadata_video_id] FOREIGN KEY ([video_id]) REFERENCES [video].[videos] ([video_id])
)
