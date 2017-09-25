If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXBAccountExtension]') And type in (N'U'))
	Drop Table [MXBAccountExtension]
Go

/****** Object:  Table [dbo].[MXBAccountExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXBAccountExtension](
	-- multi-tenancy support
	[CompanyID]				[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[BAccountID]			[int] NOT NULL,

	-- extension fields
	[TaxRegimeID]			[int] NULL DEFAULT ((0)),
	[UseCfdiCD]				[nvarchar](3) NULL,
	[IsNaturalPerson]		[bit] NULL DEFAULT ((0)),
	[DefaultOriginAccount]	[nvarchar](30) NULL,
	[DefaultPaymentMethod]	[nvarchar](50) NULL,

	CONSTRAINT [MXBAccountExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[BAccountID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


