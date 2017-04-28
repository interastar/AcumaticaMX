If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARTranExtension]') And type in (N'U'))
	Drop Table [MXARTranExtension]
Go

/****** Object:  Table [dbo].[MXARTranExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARTranExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[INT] NOT NULL DEFAULT ((0)),
	-- Llaves de relacion
	[RefNbr]            [NVARCHAR] (15) NOT NULL,
	[LineNbr]			[INT] NOT NULL DEFAULT ((0)),
	[TranType]			[CHAR] (15) NOT NULL,

	-- Datos de Informacion Aduanera
	[CustomsInformation][nvarchar](255) NULL,

	CONSTRAINT [MXARTranExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[RefNbr] ASC,
		[LineNbr] ASC,
		[TranType] ASC
	)
)