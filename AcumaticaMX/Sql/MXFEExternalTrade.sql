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
	[RefNbr]					char(15) NOT NULL,

	[Version]					nvarchar(3) NOT NULL,
	[TransferReason]			nvarchar(2) NOT NULL,
	[OperationType]				int NOT NULL,
	[RequestKey]				nvarchar(2) NOT NULL,
	[IsOriginCertificate]		bit NOT NULL DEFAULT ((0)),
	[OriginCertificateNbr]		nvarchar(40) NOT NULL,
	[TrustworthyExporterNbr]	nvarchar(50) NOT NULL,
	[Incoterm]					nvarchar(3) NULL,
	[HasSubdivision]			bit NOT NULL DEFAULT ((0)),
	[Description]				nvarchar(300) NULL,
	[CurrencyRateAmt]			decimal(19, 6) NULL,
	[UsdTotal]					decimal(19, 4) NULL,
	[OwnerTaxRegistrationID]	nvarchar(40) NOT NULL,
	[OwnerFiscalAddress]		nvarchar(3)  NOT NULL,
	[ReceiverTaxRegistrationID]	nvarchar(40) NOT NULL,
	[ReceiverName]				nvarchar(40) NOT NULL,
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