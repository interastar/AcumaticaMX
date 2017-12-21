If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEAgreementItem]') And type in (N'U'))
	Drop Table [dbo].[MXFEAgreementItem]
Go
/****** Object:  Table [dbo].[MXFEAgreementItem] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEAgreementItem]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	[RefNbr]				nvarchar(15) NOT NULL,
	[AgreementNbr]			nvarchar(50) NOT NULL,
	[LineNbr]				int NOT NULL,
	[InventoryID]			int NOT NULL,
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

	CONSTRAINT [MXFEAgreementItem_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[AgreementNbr] ASC,
		[LineNbr] ASC,
		[InventoryID] ASC
	)
)