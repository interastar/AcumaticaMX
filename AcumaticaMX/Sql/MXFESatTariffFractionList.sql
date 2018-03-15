If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatTariffFractionList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatTariffFractionList]
Go
Create Table [dbo].[MXFESatTariffFractionList]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[TariffFractionCD]		nvarchar(8) NOT NULL,

	[UOM]					nvarchar(2) NULL,
	[TaxImp]				nvarchar(9) NULL,
	[TaxExp]				nvarchar(9) NULL,
	[Description]			nvarchar(500) NULL,
	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT MXFESatTariffFractionList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[TariffFractionCD] ASC
	)
)