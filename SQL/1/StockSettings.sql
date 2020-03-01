USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockSettings](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyAddress] [nvarchar](max) NULL,
	[CompanyEmail] [nvarchar](max) NULL,
	[CompanyPhone] [nvarchar](max) NULL,
	[CompanyLogo] [image] NULL,
	[SessionID] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

