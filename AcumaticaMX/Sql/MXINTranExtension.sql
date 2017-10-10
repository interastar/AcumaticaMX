If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINTranExtension]') And type in (N'U'))
	Drop Table [MXINTranExtension]
Go

/****** Object:  Table [dbo].[MXINTranExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINTranExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[DocType]			[nvarchar] (1)	NOT NULL,
	[RefNbr]			[nvarchar] (15) NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](255) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

	CONSTRAINT [MXINTranExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr]  ASC,
		[LineNbr] ASC
	)
)