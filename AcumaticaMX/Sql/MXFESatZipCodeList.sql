If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESatZipCodeList]') And type in (N'U'))
	Drop Table [dbo].[MXFESatZipCodeList]
Go
Create Table [dbo].[MXFESatZipCodeList]
(
	-- multi-tenancy support
	[CompanyID]			int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[ZipCodeID]	        int IDENTITY(1,1) NOT NULL,
	[ZipCodeCD]			nvarchar(5) NOT NULL,

	[State]				nvarchar(3) NOT NULL,
	[Municipality]		nvarchar(3) NULL,
	[Town]				nvarchar(3) NULL,

	-- handle concurrency
	[tstamp]			timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]		uniqueidentifier NOT NULL,
	[CreatedByScreenID]	char(8) NOT NULL,
	[CreatedDateTime]	smalldatetime NOT NULL,
	[LastModifiedByID]	uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXFESatZipCodeList_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[ZipCodeCD] ASC
	)
)