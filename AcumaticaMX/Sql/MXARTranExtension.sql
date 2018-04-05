If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARTranExtension]') And type in (N'U'))
	Drop Table [MXARTranExtension]
Go

/****** Object:  Table [dbo].[MXARTranExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARTranExtension](
	-- multi-tenancy support
	[CompanyID]				[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[TranType]				[nvarchar](3) NOT NULL,
	[RefNbr]				[nvarchar](15) NOT NULL,
	[LineNbr]				[int] NOT NULL DEFAULT ((0)),

	-- extension fields
	[ProductServiceCD]		[nvarchar](8) NULL,
	[MeasureCD]				[nvarchar](3) NULL,
	[MeasureName]			[nvarchar](1000) NULL,
	[DescriptionBackUp]		[nvarchar](1000) NULL,
	[AppliedRefNbr]			[nvarchar](15) NULL,
	[AppliedDocType]		[nvarchar](3) NULL,

)