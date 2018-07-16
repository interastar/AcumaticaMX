If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXAPTranExtension]') And type in (N'U'))
	Drop Table [MXAPTranExtension]
Go

/****** Object:  Table [dbo].[MXAPTranExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXAPTranExtension](
	-- multi-tenancy support
	[CompanyID]					[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[TranType]				[nvarchar](3) NOT NULL,
	[RefNbr]				[nvarchar](15) NOT NULL,
	[LineNbr]				[int] NOT NULL DEFAULT ((0)),

	-- extension fields
	[OperationType]			[nvarchar](50) NULL,
	
	CONSTRAINT [MXAPTranExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[TranType] ASC,
		[RefNbr] ASC,
		[LineNbr] ASC
	)
)