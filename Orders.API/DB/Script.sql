CREATE DATABASE [Orders]
CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[OrderDate] [datetime] NULL,
	[OrderStatus] [nvarchar](max) NULL,
	[TotalAmount] [decimal] NOT NULL)