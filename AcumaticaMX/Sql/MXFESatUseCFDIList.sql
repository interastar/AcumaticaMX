If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatUseCFDIList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatUseCFDIList]
Go
Create Table [dbo].[MXFESatUseCFDIList]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[UseCfdiCD]					nvarchar(3) NOT NULL,
	[Description]				nvarchar(500) NOT NULL,

	[ApplyNaturalPerson]		bit null default((0)),
	[ApplyMoralPerson]			bit null default((0)),
	[ValidityStartDate]			smalldatetime NOT NULL,
	[ValidityEndDate]			smalldatetime NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatUseCFDIList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[UseCfdiCD] ASC
	)
)