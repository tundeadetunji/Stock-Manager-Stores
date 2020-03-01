USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockProgramLog](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[LogTitle] [nvarchar](max) NULL,
	[LogDate] [nvarchar](255) NULL,
	[LogTime] [nvarchar](255) NULL,
	[LogTrigger] [nvarchar](max) NULL,
	[TriggerUsername] [nvarchar](max) NULL,
	[LogMemo] [nvarchar](max) NULL,
	[UserID] [nvarchar](max) NULL,
	[ClientID] [nvarchar](max) NULL,
	[ItemID] [nvarchar](max) NULL,
	[SessionID] [nvarchar](max) NULL,
	[LogIP] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

