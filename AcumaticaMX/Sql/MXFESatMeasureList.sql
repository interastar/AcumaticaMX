If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatMeasureList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatMeasureList]
Go
Create Table [dbo].[MXFESatMeasureList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[MeasureCD]			nvarchar(3) NOT NULL,

	[Name]				nvarchar(500) NULL,
	[Description]		nvarchar(1000) NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatMeasureList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[MeasureCD] ASC
	)
)