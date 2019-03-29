If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[ARInvoiceISDDExt]') And type in (N'U'))
	Drop Table [ARInvoiceISDDExt]
Go

/****** Object:  Table [dbo].[ARInvoiceISDDExt] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ARInvoiceISDDExt](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]			char(3) NOT NULL,
	[RefNbr]			char(15) NOT NULL,

	-- Nuevos campos extendidos
	[UsrAddendumInclude]	bit NULL DEFAULT ((0)),

	CONSTRAINT [ARInvoiceISDDExt_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
