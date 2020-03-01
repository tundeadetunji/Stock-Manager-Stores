USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockUsers](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](255) NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Birthday] [nvarchar](255) NULL,
	[City] [nvarchar](max) NULL,
	[CanChangeSetting] [bit] NULL,
	[CanRecordStock] [bit] NULL,
	[CanRecordSale] [bit] NULL,
	[CanWorkOnUser] [bit] NULL,
	[CanWorkOnClient] [bit] NULL,
	[IsEnabled] [bit] NULL,
	[Picture] [image] NULL,
	[Username] [nvarchar] (max) NULL,
	[UserPassword] [nvarchar](max) NULL,
	[SessionID] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

