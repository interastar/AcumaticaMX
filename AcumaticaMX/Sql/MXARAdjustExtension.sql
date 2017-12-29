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
	[AdjdDocType]				[CHAR] (3) NOT NULL,
	[AdjdRefNbr]				[CHAR] (15) NOT NULL,

	-- Informacion adicional
	[DocumentID]				[UNIQUEIDENTIFIER] NULL,
	[PaymentForm]				[nvarchar](3) NULL,
	[Partiality]				[INT] NULL,
	[DebtAmt]					DECIMAL(19, 4) NULL,
	[PaymentAmt]				DECIMAL(19, 4) NULL,
	[NewDebtAmt]				DECIMAL(19, 4) NULL,
	[Uuid]						[UNIQUEIDENTIFIER] NULL,
	[PaymentRefNbr]				[NVARCHAR] (15) NULL,
	[CuryID]					[NVARCHAR] (3) NULL,
	[CancelDate]				[SMALLDATETIME] NULL,
	
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