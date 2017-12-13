If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINTran]') And type in (N'U'))
	Drop Table [MXINTran]
Go

/****** Object:  Table [dbo].[MXINTran] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINTran](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[DocType]			[nvarchar] (1)	NOT NULL,
	[RefNbr]			[nvarchar] (15) NOT NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),
	[InventoryID]		[int] NOT NULL DEFAULT ((0)),
	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](255) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,

		-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT [MXINTran_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr]  ASC,
		[LineNbr] ASC
	)
)