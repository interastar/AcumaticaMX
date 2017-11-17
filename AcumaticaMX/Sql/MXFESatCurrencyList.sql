If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXFESatCurrencyList]') And type in (N'U'))
	Drop Table [MXFESatCurrencyList]
Go

/****** Object:  Table [dbo].[MXFESatCurrencyList] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXFESatCurrencyList](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[CurrencyCD]				[nvarchar](3) NOT NULL,

	-- extension fields
	[Description]				[nvarchar](255) NOT NULL,
	[Precision]					[int] NOT NULL DEFAULT ((0)),
	[Variation]					[nvarchar](5) NOT NULL,
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXFESatCurrencyList_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[CurrencyCD] ASC
	)
)