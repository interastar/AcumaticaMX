If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatLocationList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatLocationList]
Go
Create Table [dbo].[MXFESatLocationList]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[LocationCD]				nvarchar(2) NOT NULL,
	[State]						nvarchar(3) NOT NULL,

	[Name]						nvarchar(500) NULL,
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatLocationList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[LocationCD] ASC,
		[State] ASC
	)
)