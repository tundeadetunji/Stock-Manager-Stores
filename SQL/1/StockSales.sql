USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockSales](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [nvarchar](max) NULL,
	[Item] [nvarchar](max) NULL,
	[UnitPrice] [nvarchar](255) NULL,
	[QuantityBought] [nvarchar](255) NULL,
	[Discount] [nvarchar](255) NULL,
	[UseDiscount] [bit] NULL,
	[RecordDate] [nvarchar](255) NULL,
	[RecordTime] [nvarchar](255) NULL,
	[RecordMonth] [nvarchar](255) NULL,
	[RecordYear] [nvarchar](255) NULL,
	[RecordBy] [nvarchar](max) NULL,
	[UnitProfit] [nvarchar](255) NULL,
	[TotalProfit] [nvarchar](255) NULL,
	[ItemID] [nvarchar](max) NULL,
	[SessionID] [nvarchar](max) NULL,
	[ReceiptNumber] [nvarchar](max) NULL,
	[ItemRecordSerial] [nvarchar](255) NULL,
	[Gross] [nvarchar](255) NULL,
	[TotalCost] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

