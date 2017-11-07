If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXFEPayments]') And type in (N'U'))
	Drop Table [dbo].[MXFEPayments]
Go
/****** Object:  Table [dbo].[MXFEPayments] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[MXFEPayments]
(
	-- multi-tenancy support
	[CompanyID]				int NOT NULL DEFAULT ((0)),
	
	
	[PaymentRefNbr]			nvarchar(15) NOT NULL,
	[StampedUuid]			uniqueidentifier NOT NULL,
	[CustomerID]			int NOT NULL,
	[Stamp]					nvarchar(500) NOT NULL,
	[CFDSeal]				nvarchar(500) NOT NULL,
	[StampString]			nvarchar(1000) NOT NULL,
	[StampDate]				smalldatetime NOT NULL,
	[AttachedUuid]			uniqueidentifier NULL,
	[CancelDate]			smalldatetime NULL,
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

	CONSTRAINT [MXFEPayments_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[StampedUuid] ASC
	)
)