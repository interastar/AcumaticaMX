If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[ISMXVoucher]') And type in (N'U'))
	Drop Table [dbo].[ISMXVoucher]
Go
/****** Object:  Table [dbo].[ISMXVoucher] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[ISMXVoucher]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),
	[VoucherID]					int identity NOT NULL,

	-- General fields
	[Version]					nvarchar(3) NULL,
	[DocType]					nvarchar(1)  NOT NULL,
	[Serie]						nvarchar(25) NULL,
	[Folio]						nvarchar(25) NULL,
	[DocDateTime]				smalldatetime NOT NULL,
	[PaymentForm]				nvarchar(50) NOT NULL,
	[PaymentMethod]				nvarchar(50) NOT NULL,
	[PaymentTerms]				nvarchar(100) NULL,
	[ZipCode]					nvarchar(5) NOT NULL,
	[CuryID]					nvarchar(3) NOT NULL,
	[CuryRate]					decimal(19, 6) NULL,
	[DisccountAmt]				decimal(19, 6) NULL,
	[VoucherSubTotal]			decimal(19, 4) NOT NULL,
	[VoucherTotal]				decimal(19, 4) NOT NULL,
	[PacConfirmation]			nvarchar(5) NOT NULL,

	-- Seal of voucher
	[CertificateNbr]			char(20) NULL,
	[Certificate]				nvarchar(2500) NULL,
 	[SealDate]					smalldatetime NULL,
	[Seal]						nvarchar(500) NULL,
	
	-- Stamp
	[Uuid]						uniqueidentifier NULL,
	[SatCertificateNbr]			char(20) NULL,
	[StampDate]					smalldatetime NULL,
	[Stamp]						nvarchar(500) NULL,

	--	Addendum
	[QrCode]					nvarchar(95) NULL,
	[StampString]				nvarchar(1000) NULL,

	--	Status fields
	[CancelStatus]				nvarchar(50) NULL,
	[CancelDate]				smalldatetime NULL,

	--	Uniques fields for voucher
	[IssuerTaxRegistrationID]	nvarchar(13) NULL,
	[Issuer]					nvarchar(254) NULL,
	[ReceiverTaxRegistrationID]	nvarchar(13) NULL,
	[Receiver]					nvarchar(254) NULL,
	[UseCfdiCD]					nvarchar(3) NULL,
	[TaxTransferredTotal]		decimal(19, 4) NULL,
	[TaxHoldingTotal]			decimal(19, 4) NULL,

	--	Helpers
	[DocRef]					uniqueidentifier NOT NULL,
	[Module]					nvarchar(2) NOT NULL,

	-- Complementos
	[HasExternalTrade]			bit NULL DEFAULT ((0)),

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

	CONSTRAINT [ISMXVoucher_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[VoucherID] ASC
	)
)

CREATE UNIQUE NONCLUSTERED INDEX [ISMXVoucher|] ON [ISMXVoucher] 
(
    [CompanyID] ASC,
    [VoucherID] ASC
)