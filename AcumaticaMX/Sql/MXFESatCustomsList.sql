If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatCustomsList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatCustomsList]
Go
Create Table [dbo].[MXFESatCustomsList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[CustomsCD]			nvarchar(2) NOT NULL,

	[Description]		nvarchar(255) NOT NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatCustomsList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[CustomsCD] ASC
	)
)