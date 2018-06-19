If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARRegisterExtension]') And type in (N'U'))
	Drop Table [MXARRegisterExtension]
Go

/****** Object:  Table [dbo].[MXARRegisterExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARRegisterExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
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

	-- Campos de addenda
	[QrCode]			[nvarchar](95) NULL,
	[StampString]		[nvarchar](1000) NULL,

	-- Cancelación
	[CancelDate]		[smalldatetime] NULL,
	--Fecha de creación
	[DocDateTime]		[smalldatetime] NULL,

	-- Descuentos
	[DiscountReason]	[nvarchar](250) NULL,
	[UseCfdiCD]			[nvarchar](3) NULL,
	[CurrencyRate]		[decimal](19, 6) NULL,
	[Version]		[nvarchar](3) NULL,

	--Complemento de Pagos
	[PaymentDocDateTime][smalldatetime] NULL,
	[OperationNbr]		[nvarchar](100) NULL,

	-- Comercio Exterior
	[IsExternalTrade]	[bit] NULL DEFAULT ((0)),
	[IsGenericInvoice]	[bit] NULL DEFAULT ((1)),
	[RelationType]		[nvarchar](2) NULL,

	CONSTRAINT [MXARRegisterExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
