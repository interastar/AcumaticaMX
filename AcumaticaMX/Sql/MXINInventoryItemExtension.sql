If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINInventoryItemExtension]') And type in (N'U'))
	Drop Table [MXINInventoryItemExtension]
Go

/****** Object:  Table [dbo].[MXINInventoryItemExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINInventoryItemExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[InventoryID]		[int] NOT NULL DEFAULT ((0)),
	[ProductServiceCD]	[nvarchar](8) NOT  NULL,
)