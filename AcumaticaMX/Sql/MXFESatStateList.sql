If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatStateList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatStateList]
Go
Create Table [dbo].[MXFESatStateList]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[StateCD]					nvarchar(3) NOT NULL,
	[CountryCD]					nvarchar(3) NOT NULL,
	[Name]						nvarchar(250) NULL,
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatStateList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[StateCD] ASC,
		[CountryCD] ASC
	)
)