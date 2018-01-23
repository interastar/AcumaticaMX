If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatNeighborhoodList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatNeighborhoodList]
Go
Create Table [dbo].[MXFESatNeighborhoodList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[NeighborhoodCD]	nvarchar(4) NOT NULL,
	[ZipCodeCD]			nvarchar(5) NOT NULL,

	[Name]				nvarchar(500) NULL,
	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatNeighborhoodList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[NeighborhoodCD] ASC,
		[ZipCodeCD] ASC
	)
)