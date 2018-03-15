If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXCSCountryExtension]') And type in (N'U'))
	Drop Table [MXCSCountryExtension]
Go

/****** Object:  Table [dbo].[MXCSCountryExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXCSCountryExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[CountryID]			[nvarchar](2) NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[CountryCD]			[nvarchar](3)  NULL,
)