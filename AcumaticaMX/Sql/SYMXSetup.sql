If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[SYMXSetup]') And type in (N'U'))
	Drop Table [SYMXSetup]
Go

/****** Object:  Table [dbo].[SYMXSetup] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SYMXSetup](
	-- Campo de soporte multiempresa
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion de SYMXSetup
	-- Sucursal principal
	[MainBranch]		[int] NOT NULL DEFAULT ((0)),
	-- Credenciales principales
	[Credentials]				[nvarchar](25) NULL,
	-- Numero de certificado
	[CertificateNbr]			[nvarchar](20) NULL,
	-- Notes support
	[NoteID]					uniqueidentifier NULL,
	-- handle concurrency
    [tstamp]					timestamp NOT NULL,

	-- basic audit fields
    [CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]      smalldatetime NOT NULL,
	

	CONSTRAINT [SYMXSetup_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC
	)
)