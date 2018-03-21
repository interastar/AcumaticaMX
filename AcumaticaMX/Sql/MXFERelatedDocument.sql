If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFERelatedDocument]') And type in (N'U'))
	Drop Table [dbo].[MXFERelatedDocument]
Go
/****** Object:  Table [dbo].[MXFERelatedDocument] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFERelatedDocument]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),

	[RefNbr]				nvarchar(15) NOT NULL,
	[DocType]				nvarchar(3) NOT NULL,
	[RelatedRefNbr]			nvarchar(15) NOT NULL,
	[RelatedDocType]		nvarchar(3) NOT NULL,
	[RelationType]			nvarchar(2) NOT NULL,

	[Uuid]				[uniqueidentifier] NULL,

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

	CONSTRAINT [MXFERelatedDocument_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[RefNbr] ASC,
		[DocType] ASC,
		[RelatedRefNbr] ASC,
		[RelatedDocType] ASC
	)
)