If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXARPaymentNotifications]') And type in (N'U'))
	Drop Table [dbo].[MXARPaymentNotifications]
Go
Create Table [dbo].[MXARPaymentNotifications]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[RefNbr]				nvarchar(15)NOT NULL,
	[DocType]				nvarchar(3) NOT NULL,
	[LineNbr]				int IDENTITY NOT NULL,

	[StampedUuid]			uniqueidentifier NULL,
	[AttachedUuid]			uniqueidentifier NULL,
	[Send]				bit NULL default ((1)),
	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT MXARPaymentNotifications_PK PRIMARY KEY
	(
		[CompanyID] ASC,
		[RefNbr] ASC,
		[DocType] ASC,
		[LineNbr] ASC
	)
)