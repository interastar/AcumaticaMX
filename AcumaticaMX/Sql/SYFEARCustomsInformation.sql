If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[SYFEARCustomsInformation]') And type in (N'U'))
	Drop Table [SYFEARCustomsInformation]
Go

/****** Object:  Table [dbo].[SYFEARCustomsInformation] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SYFEARCustomsInformation](

	-- Campo de soporte multiempresa
	[CompanyID]					[INT] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion por factura
	[RegisterID]				[INT] IDENTITY NOT NULL,
	[RefNbr]					[NVARCHAR] (15) NOT NULL,
	[LineNbr]					[INT] NOT NULL DEFAULT ((0)),
	[TranType]					[CHAR] (15) NOT NULL,

	-- Informacion adicional
	[CustomsInformation]		[NVARCHAR](2500) NULL,

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
		[RegisterID] ASC
    )
)
