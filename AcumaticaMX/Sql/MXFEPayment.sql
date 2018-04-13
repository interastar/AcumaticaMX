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
	
	
	[RefNbr]				nvarchar(15) NOT NULL,
	[Uuid]					uniqueidentifier NOT NULL,
	[CustomerID]			int NOT NULL,
	[Stamp]					nvarchar(500) NOT NULL,
	[Seal]					nvarchar(500) NOT NULL,
	[StampString]			nvarchar(1000) NOT NULL,
	[StampDate]				smalldatetime NOT NULL,
	[CancelDate]			smalldatetime NULL,
	[QrCode]				nvarchar(95) NULL,
	[Version]               nvarchar(3) NULL,
	[Sended]				bit NULL DEFAULT ((0)),
	--Opcionales
	[OperationNbr]			nvarchar(100) NULL,
	[RfcEmisorCtaOrd]		nvarchar(13) NULL,
	[NomBancoOrdExt]		nvarchar(300) NULL,
	[CtaOrdenante]			nvarchar(50) NULL,
	[RfcEmisorCtaBen]		nvarchar(13) NULL,
	[CtaBeneficiario]		nvarchar(50) NULL,
	[TipoCadPago]			nvarchar(2) NULL,
	[CertPago]				nvarchar(500) NULL,
	[CadPago]				nvarchar(max) NULL,
	[SelloPago]				nvarchar(500) NULL,
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
		[Uuid] ASC
	)
)

CREATE UNIQUE NONCLUSTERED INDEX [MXFEPayment|] ON [MXFEPayment] 
(
    [CompanyID] ASC,
    [RefNbr] ASC
)