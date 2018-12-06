If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXSOShipmentADExtension]') And type in (N'U'))
	Drop Table [MXSOShipmentADExtension]
Go

/****** Object:  Table [dbo].[MXSOShipmentADExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXSOShipmentADExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	[ShipmentNbr]			char(15) NOT NULL,

	-- Nuevos campos extendidos
	[EarlyInvoice]			bit NULL DEFAULT ((0)),

	CONSTRAINT [MXSOShipmentADExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ShipmentNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
