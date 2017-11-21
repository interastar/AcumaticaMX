If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXCACashAccountExtension]') And type in (N'U'))
	Drop Table [MXCACashAccountExtension]
Go

/****** Object:  Table [dbo].[MXCACashAccountExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXCACashAccountExtension](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion del Documento de Recepcion y la Linea
	[CashAccountID]		[int] NOT NULL DEFAULT ((0)),

	-- Datos de Informacion Aduanera
	[BankCD]			[nvarchar](3)  NULL,
	[BankAccount]		[nvarchar](50)  NULL,
)