If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[ISMXPayload]') And type in (N'U'))
	Drop Table [dbo].[ISMXPayload]
Go
/****** Object:  Table [dbo].[ISMXPayload] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Create Table [dbo].[ISMXPayload]
(
	-- multi-tenancy support
	[CompanyID]					int NOT NULL DEFAULT ((0)),
	[VoucherID]					int identity NOT NULL,

	-- General fields
	[TotalTaxes]				decimal(19, 4) NOT NULL,

	-- Notes support
	[NoteID]					uniqueidentifier NULL,
	-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT [ISMXPayload_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[VoucherID] ASC
	)
)

CREATE UNIQUE NONCLUSTERED INDEX [ISMXPayload|] ON [ISMXPayload] 
(
    [CompanyID] ASC,
    [VoucherID] ASC
)