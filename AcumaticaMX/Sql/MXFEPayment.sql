If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEPayment]') And type in (N'U'))
	Drop Table [dbo].[MXFEPayment]
Go
/****** Object:  Table [dbo].[MXFEPayments] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEPayment]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	[TypeP]					nvarchar(1)	 NULL,
	[RefNbr]				nvarchar(15) NOT NULL,
	[DocType]				nvarchar(3)  NOT NULL,
	[CustomerID]			int NOT NULL,
	[DocDate]				smalldatetime NOT NULL,
	[Serie]					nvarchar(25) NULL,
	[CancelDate]			smalldatetime NULL,
	[CancelStatus]			nvarchar(50) NULL,
	[Folio]					nvarchar(25) NULL,
	[UseCfdiCD]				nvarchar(3) NULL,
	-- Timbrado
	[CertificateNum]		char(20) NULL,
	[Certificate]			nvarchar(2500) NULL,
	[Uuid]					uniqueidentifier NULL,
	[Stamp]					nvarchar(500) NULL,
	[Seal]					nvarchar(500) NULL,
 	[SealDate]				smalldatetime NULL,
	[StampString]			nvarchar(1000) NULL,
	[StampDate]				smalldatetime NULL,
	[QrCode]				nvarchar(95) NULL,
	[SatCertificateNum]		char(20) NULL,
	[Version]               nvarchar(3) NULL,
	[PaymentVersion]        nvarchar(3) NULL,
	--
	[Sended]				bit NULL DEFAULT ((0)),
	-- Notes support
	[NoteID]				uniqueidentifier NULL,
	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT [MXFEPayment_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[RefNbr] ASC
	)
)

CREATE UNIQUE NONCLUSTERED INDEX [MXFEPayment|] ON [MXFEPayment] 
(
    [CompanyID] ASC,
    [RefNbr] ASC
)