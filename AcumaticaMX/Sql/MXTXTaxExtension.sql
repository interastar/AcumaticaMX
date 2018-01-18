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

	-- Llave de la tabla original
	[TaxID]				[nvarchar] (30)	NOT NULL,

	-- Impuesto SAT
	[SatTax]			[nvarchar](4) NOT NULL,
	[Exempt]			[bit] NOT NULL DEFAULT ((0)),

	CONSTRAINT [MXTXTaxExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[TaxID] ASC
	)
)