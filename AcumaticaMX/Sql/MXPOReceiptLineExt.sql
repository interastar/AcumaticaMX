If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXPOReceiptLineExt]') And type in (N'U'))
	Drop Table [MXPOReceiptLineExt]
Go

/****** Object:  Table [dbo].[MXPOReceiptLineExt] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXPOReceiptLineExt](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion de orden de compra con las lineas
	[ReceiptNbr]		[nvarchar] (15)    NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](25) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

	CONSTRAINT [MXPOReceiptLineExt_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ReceiptNbr] ASC,
		[LineNbr] ASC
	)
)
