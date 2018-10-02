If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXGLBatchExtension]') And type in (N'U'))
	Drop Table [MXGLBatchExtension]
Go

/****** Object:  Table [dbo].[MXGLBatchExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXGLBatchExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (APRegister en Acumatica)
	[Module]			char(2) NOT NULL,
	[BatchNbr]			nvarchar(15) NOT NULL,

	--CFDI Relacionado
	[RelCfdi]			BIT NULL DEFAULT ((0)),

	-- Datos del comprobante fiscal
	[TaxRegistrationID] [nvarchar](50) NULL,
	[Name]				[nvarchar](100) NULL,
	[Folio]				[nvarchar](25) NULL,
	[Uuid]				[uniqueidentifier] NULL,
	[DocDate]			[smalldatetime] NULL,
	[TotalTaxes]		[decimal](19, 4) NULL,
	[TotalAmount]		[decimal](19, 4) NULL,
	[DocumentType]		[nvarchar](1) NULL,

	CONSTRAINT [MXGLBatchExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[Module] ASC,
		[BatchNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
