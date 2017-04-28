If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXPOReceiptLineExtension]') And type in (N'U'))
	Drop Table [MXPOReceiptLineExtension]
Go

/****** Object:  Table [dbo].[MXPOReceiptLineExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXPOReceiptLineExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion de orden de compra con las lineas
	[ReceiptNbr]		[nvarchar] (15)    NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](25) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

	CONSTRAINT [MXPOReceiptLineExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ReceiptNbr] ASC,
		[LineNbr] ASC
	)
)
