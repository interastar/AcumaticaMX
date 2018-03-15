If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatIncotermList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatIncotermList]
Go
Create Table [dbo].[MXFESatIncotermList]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[IncotermCD]			nvarchar(3) NOT NULL,

	[Description]			nvarchar(250) NULL,

	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT MXFESatIncotermList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[IncotermCD] ASC
	)
)