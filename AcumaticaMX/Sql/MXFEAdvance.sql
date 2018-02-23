If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEAdvance]') And type in (N'U'))
	Drop Table [dbo].[MXFEAdvance]
Go
/****** Object:  Table [dbo].[MXFEAdvance] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEAdvance]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	[RefNbr]				nvarchar(15) NOT NULL,
	[DocType]				nvarchar(3) NOT NULL,
	[AdvanceRefNbr]			nvarchar(15) NOT NULL,
	[AdvanceDocType]		nvarchar(3) NOT NULL,

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

	CONSTRAINT [MXFEAdvance_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[RefNbr] ASC,
		[DocType] ASC,
		[AdvanceRefNbr] ASC,
		[AdvanceDocType] ASC
	)
)