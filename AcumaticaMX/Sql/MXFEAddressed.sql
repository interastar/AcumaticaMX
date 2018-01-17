If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEAddressed]') And type in (N'U'))
	Drop Table [dbo].[MXFEAddressed]
Go
/****** Object:  Table [dbo].[MXFEAddressed] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEAddressed]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),
	[DocType]					char(3) NOT NULL,
	[RefNbr]					nvarchar(15) NOT NULL,

	[HasAddressed]				bit NULL DEFAULT ((0)),
	[ReceiverTaxRegistrationID]	nvarchar(40) NULL,
	[ReceiverName]				nvarchar(40) NULL,
	[Street]					nvarchar(100) NULL,
	[OutdoorNumber]				nvarchar(55) NULL,
	[IndoorNumber]				nvarchar(55) NULL,
	[Neighborhood]				nvarchar(120) NULL,
	[Location]					nvarchar(120) NULL,
	[Municipality]				nvarchar(120) NULL,
	[State]						nvarchar(30) NULL,
	[Country]					nvarchar(3) NULL,
	[ZipCode]					nvarchar(12) NULL,
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

	CONSTRAINT [MXFEAddressede_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
	)
)