If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEAgreement]') And type in (N'U'))
	Drop Table [dbo].[MXFEAgreement]
Go
/****** Object:  Table [dbo].[MXFEAgreement] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEAgreement]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	[RefNbr]				nvarchar(15) NOT NULL,
	[AgreementNbr]			nvarchar(50) NOT NULL,
	[CustomerID]			int NOT NULL,
	[AgreementName]			nvarchar(50) NOT NULL,
	[StartDate]				smalldatetime NOT NULL,
	[EndDate]				smalldatetime NOT NULL,
	[LineCntr]				int NOT NULL,
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

	CONSTRAINT [MXFEAgreement_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[AgreementNbr] ASC,
		[CustomerID] ASC
	)
)