If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatTaxRegimList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatTaxRegimList]
Go
Create Table [dbo].[MXFESatTaxRegimList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[TaxRegimID]	    int NOT NULL,
	[Description]		nvarchar(500) NOT NULL,

	[ApplyNaturalPerson]bit null default((0)),
	[ApplyMoralPerson]	bit null default((0)),
	[ValidityStartDate]	smalldatetime NOT NULL,
	[ValidityEndDate]	smalldatetime NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatTaxRegimList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[TaxRegimID] ASC
	)
)