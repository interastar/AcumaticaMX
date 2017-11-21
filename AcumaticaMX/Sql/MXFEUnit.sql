If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXFEUnit]') And type in (N'U'))
	Drop Table [MXFEUnit]
Go

/****** Object:  Table [dbo].[MXFEUnit] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXFEUnit](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[UnitCD]					[nvarchar](25) NOT NULL,

	-- extension fields
	[MeasureCD]					[nvarchar](3) NOT NULL,

	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXFEUnit_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[UnitCD] ASC
	)
)