USE [Database_Name]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockStock](
	[RecordSerial] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Item] [nvarchar](max) NULL,
	[Unit] [nvarchar](max) NULL,
	[UnitCost] [nvarchar](255) NULL,
	[UnitPrice] [nvarchar](255) NULL,
	[QuantityBought] [nvarchar](255) NULL,
	[CriticalQuantity] [nvarchar](255) NULL,
	[QuantityLevel] [nvarchar](255) NULL,
	[Discount] [nvarchar](255) NULL,
	[DiscountUnits] [nvarchar](255) NULL,
	[UseDiscount] [bit] NULL,
	[Picture] [image] NULL,
	[RecordBy] [nvarchar](max) NULL,
	[PreviousQuantity] [nvarchar](255) NULL,
	[Quantity] [nvarchar](255) NULL,
	[RecordDate] [nvarchar](255) NULL,
	[RecordTime] [nvarchar](255) NULL,
	[UnitProfit] [nvarchar](255) NULL,
	[TotalProfit] [nvarchar](255) NULL,
	[ItemID] [nvarchar](max) NULL,
	[SessionID] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

