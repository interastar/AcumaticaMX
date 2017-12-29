If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINInventoryParts]') And type in (N'U'))
	Drop Table [MXINInventoryParts]
Go

/****** Object:  Table [dbo].[MXINInventoryParts] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXINInventoryParts](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[KitInventoryID]			[int]NOT NULL,
	[KitLotSerialNbr]			[nvarchar](50) NOT NULL,
	[KitNbr]					[int] NOT NULL,
	[InventoryID]				[int] NOT NULL,
	[LotSerialNbr]				[nvarchar](50) NOT NULL,
	[Qty]						[decimal](25, 6) NOT NULL,
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,
	
	CONSTRAINT [MXINInventoryParts_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[KitInventoryID] ASC,
		[KitLotSerialNbr] ASC,
		[KitNbr] ASC,
		[InventoryID] ASC,
		[LotSerialNbr] ASC,
		[Qty] ASC
	)
)