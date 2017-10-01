If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXINItemLotSerial]') And type in (N'U'))
	Drop Table [MXINItemLotSerial]
Go

/****** Object:  Table [dbo].[MXINItemLotSerial] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MXINItemLotSerial](
	-- Campo de soporte multiempresa
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- Llaves de relacion
	[InventoryID]		[int] NOT NULL DEFAULT ((0)),
	[LotSerialNbr]		[nvarchar] (50) NOT NULL,
	[RefNbr]			[nvarchar] (15) NOT NULL, 
	-- Numero de referencia de la recepción con la cual entro por primera vez 
	-- Datos de Informacion Aduanera
	[Customs]			[nvarchar](25) NULL,
	[ImportDate]		[smalldatetime] NULL,
	[RequestNbr]		[nvarchar](50) NULL,
	[CustomsRequestNbr]	[nvarchar](50) NULL,
	[LineNbr]			[int] NOT NULL DEFAULT ((0)),  -- Numerp de linea de la recepción (uso futura modificación)
	[ItemSold]			[bit] NOT NULL DEFAULT ((0)),  -- Indica si el item ya ha sido vendido 
	[BatchSold]			[bit] NOT NULL DEFAULT ((0)),  -- Indica si la información aduanera puede ser modificada
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

	CONSTRAINT [MXINItemLotSerial_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID]		ASC,
		[InventoryID]   ASC,
		[LotSerialNbr]  ASC,
		[RefNbr]		ASC,
		[LineNbr]		ASC
	)
)