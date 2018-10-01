If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARAdjustExtension]') And type in (N'U'))
	Drop Table [MXARAdjustExtension]
Go

/****** Object:  Table [dbo].[MXARAdjustExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARAdjustExtension](

	-- Campo de soporte multiempresa
	[CompanyID]					[INT] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion por pago
	[AdjgDocType]				[NVARCHAR](3) NOT NULL,
	[AdjgRefNbr]				[NVARCHAR] (15) NOT NULL,
	[AdjNbr]					[INT] NOT NULL DEFAULT ((0)),
	[AdjdDocType]				[NVARCHAR](3) NOT NULL,
	[AdjdRefNbr]				[NVARCHAR] (15) NOT NULL,

	-- Informacion adicional
	[DocumentID]				[UNIQUEIDENTIFIER] NULL,
	[PaymentForm]				[NVARCHAR](3) NULL,
	[Partiality]				[INT] NULL,
	[DebtAmt]					DECIMAL(19, 4) NULL,
	[NewDebtAmt]				DECIMAL(19, 4) NULL,
	[CancelDate]				[SMALLDATETIME] NULL,

	-- Datos generales del pago

	[PaymentRefNbr]				[NVARCHAR] (15) NULL,
	[PaymentDate]				smalldatetime NULL,
	[Uuid]						[UNIQUEIDENTIFIER] NULL,
	[PaymentAmt]				DECIMAL(19, 4) NULL,
	[CuryIDP]					[NVARCHAR] (3) NULL,
	[PaymentMethodP]			[NVARCHAR] (2) NULL,
	[CurrencyRateP]				[decimal](19, 6) NULL,

	--Opcionales
	[OperationNbr]			nvarchar(100) NULL,
	[RfcEmisorCtaOrd]		nvarchar(13) NULL,
	[NomBancoOrdExt]		nvarchar(300) NULL,
	[CtaOrdenante]			nvarchar(50) NULL,
	[RfcEmisorCtaBen]		nvarchar(13) NULL,
	[CtaBeneficiario]		nvarchar(50) NULL,
	[TipoCadPago]			nvarchar(2) NULL,
	[CertPago]				nvarchar(500) NULL,
	[CadPago]				nvarchar(max) NULL,
	[SelloPago]				nvarchar(500) NULL,
	
	CONSTRAINT MXARAdjustExtension_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[AdjgDocType] ASC,
		[AdjgRefNbr] ASC,
		[AdjNbr] ASC,
		[AdjdDocType] ASC,
		[AdjdRefNbr] ASC
    )
)