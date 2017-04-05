If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXCESatMoneyList]') And type in (N'U'))
	Drop Table [dbo].[MXCESatMoneyList]
Go
Create Table [dbo].[MXCESatMoneyList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[MoneyCodeCD]		nvarchar(4) NOT NULL,
	[MoneyName]			nvarchar(255) NOT NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXCESatMoneyList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[MoneyCodeCD] ASC
	)
)