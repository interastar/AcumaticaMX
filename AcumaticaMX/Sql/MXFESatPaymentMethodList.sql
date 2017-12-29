If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatPaymentMethodList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatPaymentMethodList]
Go
Create Table [dbo].[MXFESatPaymentMethodList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[SatPaymentMethod]	nvarchar(2) NOT NULL,

	[Description]		nvarchar(500) NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatPaymentMethodList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[SatPaymentMethod] ASC
	)
)