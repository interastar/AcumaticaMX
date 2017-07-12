If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[SYFEPOReceiptLineExt]') And type in (N'U'))
	Drop Table [SYFEPOReceiptLineExt]
Go

/****** Object:  Table [dbo].[SYFEPOReceiptLineExt] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SYFEPOReceiptLineExt](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion de orden de compra con las lineas
	[ReceiptNbr]		[nvarchar] (15)    NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](25) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

	CONSTRAINT [SYFEPOReceiptLineExt_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ReceiptNbr] ASC,
		[LineNbr] ASC
	)
)
