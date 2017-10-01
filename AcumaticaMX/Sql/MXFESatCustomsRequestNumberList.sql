If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatCustomsRequestNumberList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatCustomsRequestNumberList]
Go
Create Table [dbo].[MXFESatCustomsRequestNumberList]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[CustomsRequestNumberID]uniqueidentifier NOT NULL,
	-- Fields
	[CustomsCD]				nvarchar(2) NOT NULL,
	[Patent]				int NOT NULL,
	[FiscalExcercise]		int NOT NULL,


	[Qty]					nvarchar(6) NOT NULL,
	[ValidityStartDate]		smalldatetime NULL,
	[ValidityEndDate]		smalldatetime NULL,

	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT MXFESatCustomsRequestNumberList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[CustomsRequestNumberID] ASC
	)
)