USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockClients](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](255) NULL,
	[CustomerID] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Birthday] [nvarchar](255) NULL,
	[City] [nvarchar](max) NULL,
	[Picture] [image] NULL,
	[Spent] [nvarchar](max) NULL,
	[SessionID] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

