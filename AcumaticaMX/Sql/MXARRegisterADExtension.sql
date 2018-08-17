If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARRegisterADExtension]') And type in (N'U'))
	Drop Table [MXARRegisterADExtension]
Go

/****** Object:  Table [dbo].[MXARRegisterADExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARRegisterADExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]			char(3) NOT NULL,
	[RefNbr]			char(15) NOT NULL,

	-- Nuevos campos extendidos
	[OrderTypeSO]			char(2) NULL,
	[OrderNbrSO]			nvarchar(15) NULL,
	[CreditMemoCheck]		bit NULL DEFAULT ((0)),
	[EarlyInvoice]			bit NULL DEFAULT ((0)),

	CONSTRAINT [MXARRegisterADExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
