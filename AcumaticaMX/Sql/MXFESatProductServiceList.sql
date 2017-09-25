If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatProductServiceList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatProductServiceList]
Go
Create Table [dbo].[MXFESatProductServiceList]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[ProductServiceCD]			nvarchar(8) NOT NULL,

	[Description]				nvarchar(500) NOT NULL,
	[ValidityStartDate]			smalldatetime NOT NULL,
	[ValidityEndDate]			smalldatetime NULL,
	[TransferredIVA]			nvarchar(15) NULL,
	[TransferredIEPS]			nvarchar(15) NULL,
	[IncludeComplement]			nvarchar(50) NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatProductServiceList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[ProductServiceCD] ASC
	)
)