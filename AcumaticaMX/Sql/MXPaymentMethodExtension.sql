If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXPaymentMethodExtension]') And type in (N'U'))
	Drop Table [dbo].[MXPaymentMethodExtension]
Go
Create Table [dbo].[MXPaymentMethodExtension]
(
	-- multi-tenancy support

    [CompanyID]				int NOT NULL DEFAULT ((0)),
	[PaymentMethodID]		nvarchar(10) NOT NULL,

	-- Available Sat Payment Methods
	[SatPaymentMethod]		nvarchar(2) NOT NULL,

	CONSTRAINT MXPaymentMethodExtension_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[PaymentMethodID] ASC
    )
)