If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINTranExt]') And type in (N'U'))
	Drop Table [MXINTranExt]
Go

/****** Object:  Table [dbo].[MXINTranExt] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINTranExt](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[DocType]			[nvarchar] (1)	NOT NULL,
	[RefNbr]			[nvarchar] (15) NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](25) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

	CONSTRAINT [MXINTranExt_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr]  ASC,
		[LineNbr] ASC
	)
)