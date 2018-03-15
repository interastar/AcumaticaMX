If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXCSShipTermsExtension]') And type in (N'U'))
	Drop Table [MXCSShipTermsExtension]
Go

/****** Object:  Table [dbo].[MXCSShipTermsExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXCSShipTermsExtension](
	-- Campo de soporte multiempresa
	[CompanyID]		[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[ShipTermsID]	[nvarchar] (10)    NOT NULL,
	[IncotermCD]	[nvarchar] (3) NOT  NULL,
)