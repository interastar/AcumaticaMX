If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXFECurrency]') And type in (N'U'))
	Drop Table [MXFECurrency]
Go

/****** Object:  Table [dbo].[MXFECurrency] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXFECurrency](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[CuryID]					[nvarchar](5) NOT NULL,

	-- extension fields
	[CurrencyCD]					[nvarchar](3) NOT NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXFECurrency_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[CuryID] ASC
	)
)