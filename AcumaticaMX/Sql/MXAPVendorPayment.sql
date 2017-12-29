If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXAPVendorPayments]') And type in (N'U'))
	Drop Table [MXAPVendorPayments]
Go

/****** Object:  Table [dbo].[MXAPVendorPayments] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXAPVendorPayments](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[BAccountID]				[int] NOT NULL DEFAULT ((0)),
	[LineNbr]					[int] IDENTITY NOT NULL,

	-- extension fields
	[PaymentMethod]				[nvarchar](50) NOT NULL,
	[BankCD]					[nvarchar](3) NOT NULL,
	[BankAccount]				[nvarchar](50) NOT NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXAPVendorPayments_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[BAccountID] ASC,
		[LineNbr] ASC
	)
)