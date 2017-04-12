If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARExternalTrade]') And type in (N'U'))
	Drop Table MXARExternalTrade
Go

/****** Object:  Table [dbo].[MXARExternalTrade] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].MXARExternalTrade(

	-- Campo de soporte multiempresa
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]					char(3) NOT NULL,
	[RefNbr]					char(15) NOT NULL,

	--Datos Generales de comercio exterior
	[TransferReason]			[nvarchar](3) NULL,
	[OperationType]				[int] NULL DEFAULT ((2)),
	[RequestKey]				[nvarchar](3) NULL,
	[OriginCertified]			bit DEFAULT ((0)),
	[OriginCertifiedNumber]		[nvarchar](40) NULL,
	[Incoterm]					[nvarchar](4) NULL,
	[Subdivision]				bit DEFAULT ((0)),
	[ExchangeRate]				[nvarchar](7) NULL,
	[Observations]				[nvarchar](255) NULL,

		-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXARExternalTrade_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
    )
)