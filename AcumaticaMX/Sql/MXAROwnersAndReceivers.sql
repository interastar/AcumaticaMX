If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXAROwnersAndReceivers]') And type in (N'U'))
	Drop Table MXAROwnersAndReceivers
Go

/****** Object:  Table [dbo].[MXAROwnersAndReceivers] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].MXAROwnersAndReceivers(

	-- Campo de soporte multiempresa
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]					char(3) NOT NULL,
	[RefNbr]					char(15) NOT NULL,

	--Datos Generales de comercio exterior
	[BAccountID]				[int] NOT NULL DEFAULT ((0)),
	[BAccountType]				[nvarchar](2) NULL,
	[AddressID]					[int] NOT NULL DEFAULT ((0)),
	[RevisionID]				[int] NOT NULL DEFAULT ((0)),

		-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXAROwnersAndReceivers_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
    )
)