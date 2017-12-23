If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARCustomerPaymentMethodExtension]') And type in (N'U'))
	Drop Table [MXARCustomerPaymentMethodExtension]
Go

/****** Object:  Table [dbo].[MXARCustomerPaymentMethodExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARCustomerPaymentMethodExtension](

	-- Campo de soporte multiempresa
	[CompanyID]					[INT] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion por pago
	[PMInstanceID]				[INT] NOT NULL DEFAULT ((0)),

	-- Informacion adicional
	[BankCD]					[NVARCHAR] (15) NULL,

	CONSTRAINT MXARCustomerPaymentMethodExtension_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[PMInstanceID] ASC
    )
)