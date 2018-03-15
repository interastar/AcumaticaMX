If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARTranExternalTrade]') And type in (N'U'))
	Drop Table [MXARTranExternalTrade]
Go

/****** Object:  Table [dbo].[MXARTranExternalTrade] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARTranExternalTrade](

	-- Campo de soporte multiempresa
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relación con documento contable (ARRegister en Acumatica)
	[DocType]					char(3) NOT NULL,
	[RefNbr]					char(15) NOT NULL,

	--Datos Generales de comercio exterior
	[LineNbr]					[int] NOT NULL DEFAULT ((0)),
	[TariffFraction]			[nvarchar](25) NOT NULL,
	[TariffUnit]				[nvarchar](2) NOT NULL,
	[TariffUnitValue]			[decimal] NULL DEFAULT ((0)),
	[TariffTotalValue]			[decimal] NULL DEFAULT ((0)),
	[Brand]						[nvarchar](35) NULL,
	[Model]						[nvarchar](35) NULL,
	[SubModel]					[nvarchar](35) NULL,
	[SerieNumber]				[nvarchar](35) NULL,

		-- handle concurrency
	[tstamp]					timestamp NOT NULL,

	-- basic audit fields
	[CreatedByID]				uniqueidentifier NOT NULL,
	[CreatedByScreenID]			char(8) NOT NULL,
	[CreatedDateTime]			smalldatetime NOT NULL,
	[LastModifiedByID]			uniqueidentifier NOT NULL,
	[LastModifiedByScreenID]	char(8) NOT NULL,
	[LastModifiedDateTime]		smalldatetime NOT NULL,

	CONSTRAINT MXARTranExternalTrade_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC,
		[LineNbr] ASC
    )
)