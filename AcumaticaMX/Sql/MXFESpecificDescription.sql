If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFESpecificDescription]') And type in (N'U'))
	Drop Table [dbo].[MXFESpecificDescription]
Go
/****** Object:  Table [dbo].[MXFESpecificDescription] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFESpecificDescription]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	-- Llaves de relación
	[RefNbr]				char(15) NOT NULL,
	[DocType]				char(3) NOT NULL,
	[InventoryID]			int NOT NULL,
	[CommodityLineNbr]		int NOT NULL,
	[LineNbr]				int NOT NULL,

	[Brand]					nvarchar(100) NOT NULL,
	[SubModel]				nvarchar(50) NOT NULL,
	[SerieNbr]				nvarchar(50) NOT NULL,
	-- Notes support
	[NoteID]				uniqueidentifier NULL,
	-- handle concurrency
	[tstamp]				timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]			uniqueidentifier NOT NULL,
	[CreatedByScreenID]		char(8) NOT NULL,
	[CreatedDateTime]		smalldatetime NOT NULL,
	[LastModifiedByID]		uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]char(8) NOT NULL,
	[LastModifiedDateTime]	smalldatetime NOT NULL,

	CONSTRAINT [MXFESpecificDescription_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC,
		[InventoryID] ASC,
		[CommodityLineNbr] ASC,
		[LineNbr] ASC
	)
)