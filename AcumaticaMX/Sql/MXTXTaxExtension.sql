If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXTXTaxExtension]') And type in (N'U'))
	Drop Table [MXTXTaxExtension]
Go

/****** Object:  Table [dbo].[MXTXTaxExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXTXTaxExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[TaxID]				[nvarchar] (30)	NOT NULL,

	-- Datos de Informacion Aduanera
	[SatTax]			[nvarchar](4) NOT NULL,
	[SatTaxType]		[nvarchar](1) NOT NULL,

	CONSTRAINT [MXTXTaxExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[TaxID] ASC
	)
)