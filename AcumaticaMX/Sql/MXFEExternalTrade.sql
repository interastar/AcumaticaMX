If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEExternalTrade]') And type in (N'U'))
	Drop Table [dbo].[MXFEExternalTrade]
Go
/****** Object:  Table [dbo].[MXFEExternalTrade] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEExternalTrade]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),
	[DocType]					char(3) NOT NULL,
	[RefNbr]					nvarchar(15) NOT NULL,

	[Version]					nvarchar(3) NOT NULL,
	[TransferReason]			nvarchar(2) NULL,
	[OperationType]				int NULL,
	[RequestKey]				nvarchar(2) NULL,
	[IsOriginCertificate]		bit NULL DEFAULT ((0)),
	[OriginCertificateNbr]		nvarchar(40) NULL,
	[TrustworthyExporterNbr]	nvarchar(50) NULL,
	[Incoterm]					nvarchar(3) NULL,
	[HasSubdivision]			bit NULL DEFAULT ((0)),
	[Description]				nvarchar(300) NULL,
	[CurrencyRateAmt]			decimal(19, 6) NULL,
	[UsdTotal]					decimal(19, 4) NULL,
	[OwnerTaxRegistrationID]	nvarchar(40) NULL,
	[OwnerFiscalAddress]		nvarchar(3) NULL,
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
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT [MXFEExternalTrade_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
	)
)