If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXFEPaymentTran]') And type in (N'U'))
	Drop Table [MXFEPaymentTran]
Go

/****** Object:  Table [dbo].[MXFEPaymentTran] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXFEPaymentTran](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[DocType]			[nvarchar] (3)	NOT NULL,
	[RefNbr]			[nvarchar] (15) NOT NULL,
	[AdjgDocType]		[NVARCHAR](3) NOT NULL,
	[AdjgRefNbr]		[NVARCHAR] (15) NOT NULL,
	[AdjNbr]			[INT] NOT NULL DEFAULT ((0)),
	[AdjdDocType]		[NVARCHAR](3) NOT NULL,
	[AdjdRefNbr]		[NVARCHAR] (15) NOT NULL,

	-- Notes support
	[NoteID]				uniqueidentifier NULL,
	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT [MXFEPaymentTran_PK] PRIMARY KEY CLUSTERED 
	(
			[CompanyID] ASC,
			[DocType] ASC,
			[RefNbr] ASC,
			[AdjgDocType]	ASC,
			[AdjgRefNbr]	ASC,
			[AdjNbr]	ASC,
			[AdjdDocType]	ASC,
			[AdjdRefNbr]	ASC

	)
)