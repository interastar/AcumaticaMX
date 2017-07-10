If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARCustomsInformation]') And type in (N'U'))
	Drop Table [MXARCustomsInformation]
Go

/****** Object:  Table [dbo].[MXARCustomsInformation] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARCustomsInformation](

	-- Campo de soporte multiempresa
	[CompanyID]					[INT] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion por factura
	[NumericKey]				[INT] IDENTITY NOT NULL,
	[RefNbr]					[NVARCHAR] (15) NOT NULL,
	[LineNbr]					[INT] NOT NULL DEFAULT ((0)),
	[TranType]					[CHAR] (15) NOT NULL,

	-- Informacion adicional
	[CustomsInformation]		[NVARCHAR](500) NULL,

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
	[LastModifiedDateTime]      smalldatetime NOT NULL,
	
	CONSTRAINT MXARCustomsInformation_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[NumericKey] ASC
    )
)
