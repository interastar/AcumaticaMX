If Exists (Select * From sys.objects Where object_id = OBJECT_ID(N'[MXARRegisterExtension]') And type in (N'U'))
	Drop Table [MXARRegisterExtension]
Go

/****** Object:  Table [dbo].[MXARRegisterExtension] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MXARRegisterExtension](
	-- multi-tenancy support
	[CompanyID]			[int] NOT NULL DEFAULT ((0)),

	-- surrogate/natural key
	[DocType]			char(3) NOT NULL,
	[RefNbr]			char(15) NOT NULL,

	-- extension fields
	[Series]			[nvarchar](25) NULL,
	
	[Certificate]		[nvarchar](2500) NULL,
	[PaymentForm]		[nvarchar](50) NULL,
	[PaymentMethod]		[nvarchar](50) NULL,
	[OriginAccount]		[nchar](4) NULL,
	[PaymentConditions]	[nvarchar](100) NULL,

 	[StampDate]			[smalldatetime] NULL,
	[Uuid]				[uniqueidentifier] NULL,
	[SatCertificateNum]	[nchar](20) NULL,
	[CfdStamp]			[nvarchar](500) NULL,
	[SatStamp]			[nvarchar](500) NULL,
		
	[QrCode]			[nvarchar](100) NULL,

	[TfdOriginalString]	[nvarchar](1000) NULL

	CONSTRAINT [MXARRegisterExtension_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DocType] ASC,
		[RefNbr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
