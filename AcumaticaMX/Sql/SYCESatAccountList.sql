If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[SYCESatAccountList]') And type in (N'U'))
	Drop Table [dbo].[SYCESatAccountList]
Go
Create Table [dbo].[SYCESatAccountList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[GroupingCodeCD]	nvarchar(6) NOT NULL,
	[GroupingCodeID]	int NOT NULL,
	
	[Level]				int NOT NULL,
	[Description]		nvarchar(255) NOT NULL,
	[ParentCD]			nvarchar(6) NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT SYCESatAccountList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[GroupingCodeCD] ASC
	)
)