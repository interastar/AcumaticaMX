If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[SYFEPaymentMethodExt]') And type in (N'U'))
	Drop Table [dbo].[SYFEPaymentMethodExt]
Go
Create Table [dbo].[SYFEPaymentMethodExt]
(
	-- multi-tenancy support

    [CompanyID]				int NOT NULL DEFAULT ((0)),
	[PaymentMethodID]		nvarchar(10) NOT NULL,

	-- Available Sat Payment Methods
	[SatPaymentMethod]		nvarchar(2) NOT NULL,

	CONSTRAINT SYFEPaymentMethodExt_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[PaymentMethodID] ASC
    )
)