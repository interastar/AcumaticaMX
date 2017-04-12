If Exists(Select* From sys.objects Where object_id = OBJECT_ID(N'[MXINUnitExtension]') And type in (N'U'))
	Drop Table [dbo].[MXINUnitExtension]
Go
Create Table [dbo].[MXINUnitExtension]
(
	-- multi-tenancy support

    [CompanyID]				int NOT NULL DEFAULT ((0)),
	[RecordID]				bigint NOT NULL DEFAULT ((0)),

	-- Available Sat Payment Methods
	[SatUnits]				nvarchar(2) NULL,

	CONSTRAINT MXINUnitExtension_PK PRIMARY KEY
    (
        [CompanyID] ASC,
		[RecordID] ASC
    )
)