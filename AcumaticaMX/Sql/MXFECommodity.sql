If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFECommodity]') And type in (N'U'))
	Drop Table [dbo].[MXFECommodity]
Go
/****** Object:  Table [dbo].[MXFECommodity] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFECommodity]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]				char(3) NOT NULL,
	[RefNbr]				char(15) NOT NULL,
	[InventoryID]			int NOT NULL,
	[LineNbr]				int NOT NULL,

	[IdentificationCD]		nvarchar(100) NOT NULL,
	[TariffFraction]		nvarchar(100) NOT NULL,
	[CustomsQty]			decimal(25,6) NOT NULL,
	[CustomsUnit]			nvarchar(2)	  NOT NULL,
	[CustomsUnitAmt]		decimal(19,4) NOT NULL,
	[UsdAmt]				decimal(19,4) NOT NULL,
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

	CONSTRAINT [MXFECommodity_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC,
		[LineNbr] ASC
	)
)