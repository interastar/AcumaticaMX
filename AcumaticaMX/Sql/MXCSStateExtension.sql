If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXCSStateExtension]') And type in (N'U'))
	Drop Table [MXCSStateExtension]
Go

/****** Object:  Table [dbo].[MXCSStateExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXCSStateExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[CountryID]			[nvarchar](2) NOT NULL DEFAULT ((0)),
	[StateID]			[nvarchar](50)  NULL,
	-- Datos de Informacion Aduanera
	[StateCD]			[nvarchar](3)  NULL,
)