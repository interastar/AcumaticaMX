If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXAPContactExtension]') And type in (N'U'))
	Drop Table [MXAPContactExtension]
Go

/****** Object:  Table [dbo].[MXAPContactExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXAPContactExtension](
	-- multi-tenancy support
	[CompanyID]		[int] NOT NULL DEFAULT ((0)),
	-- surrogate/natural key
	[ContactID]		[int] NOT NULL,

	-- extension fields
	[SecondLastName] [nvarchar](100) NULL,
	[PersonalID] [nvarchar](100) NULL,
	CONSTRAINT [MXAPContactExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ContactID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
