If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINInventoryKits]') And type in (N'U'))
	Drop Table [MXINInventoryKits]
Go

/****** Object:  Table [dbo].[MXINInventoryKits] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINInventoryKits](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL,

	-- surrogate/natural key
	[RefNbr]					[nvarchar](15) NOT NULL,
	[DocType]					[nvarchar](3) NOT NULL,

	[InventoryID]				[int] NOT NULL,
	[LotSerialNbr]				[nvarchar](50) NOT NULL,
	[KitNbr]					[int] NOT NULL,
	[ItemSold]					[bit] NULL DEFAULT ((0)),
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXINInventoryKits_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[InventoryID] ASC,
		[LotSerialNbr] ASC,
		[KitNbr] ASC
	)
)