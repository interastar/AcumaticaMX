If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXAPRegisterExtension]') And type in (N'U'))
	Drop Table [MXAPRegisterExtension]
Go

/****** Object:  Table [dbo].[MXAPRegisterExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXAPRegisterExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (APRegister en Acumatica)
	[DocType]			char(3) NOT NULL,
	[RefNbr]			char(15) NOT NULL,

	-- Datos del comprobante fiscal
	[Series]			[nvarchar](25) NULL,
	[PaymentForm]		[nvarchar](50) NULL,
	[PaymentMethod]		[nvarchar](50) NULL,
	[OriginAccount]		[nvarchar](20) NULL,
	[PaymentTerms]		[nvarchar](100) NULL,

	-- Datos de sello del comprobante
	[CertificateNum]	char(20) NULL,
	[Certificate]		[nvarchar](2500) NULL,
 	[SealDate]			[smalldatetime] NULL,
	-- Sello del comprobante
	[Seal]				[nvarchar](500) NULL,

	-- Datos del timbrado del comprobante
	[Uuid]				[uniqueidentifier] NULL,
	[SatCertificateNum]	char(20) NULL,
 	[StampDate]			[smalldatetime] NULL,
	-- Sello del SAT
	[Stamp]				[nvarchar](500) NULL,

	-- Cancelación
	[CancelDate]		[smalldatetime] NULL,

	-- Datos de Validación
	[DocumentType]		[nvarchar](1) NOT NULL,
	[Folio]		[nvarchar](25) NULL,
	[Import]			BIT NULL DEFAULT ((1)),
	[Provider]			[nvarchar](13) NULL,
	[TotalTaxes]		DECIMAL(19, 4) NULL,
	[TotalAmount]		DECIMAL(19, 4) NULL,

	CONSTRAINT [MXAPRegisterExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
