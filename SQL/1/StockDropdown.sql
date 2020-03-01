USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockDropdown](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Gender] [nvarchar](255) NULL,
	[Unit] [nvarchar](255) NULL
) 

GO

