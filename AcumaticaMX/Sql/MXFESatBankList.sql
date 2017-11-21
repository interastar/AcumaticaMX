If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXFESatBankList]') And type in (N'U'))
	Drop Table [MXFESatBankList]
Go

/****** Object:  Table [dbo].[MXFESatBankList] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXFESatBankList](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[BankCD]					[nvarchar](3) NOT NULL,

	-- extension fields
	[BankName]					[nvarchar](255) NOT NULL,
	[BankRFC]					[nvarchar](50) NOT NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXFESatBankListt_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[BankCD] ASC
	)
)