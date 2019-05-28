﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'SiyayaTravelAssist.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201905222152290_initialMigration'
BEGIN
    CREATE TABLE [dbo].[Bookings] (
        [Id] [int] NOT NULL IDENTITY,
        [BookingStatus] [nvarchar](max),
        [DateCreated] [datetime] NOT NULL,
        [BookingReference] [nvarchar](max),
        [BookingOrder] [nvarchar](max),
        [PaymentBalance] [float] NOT NULL,
        [PaymentType] [nvarchar](max),
        [PaymentStatus] [nvarchar](max),
        [AdditionalInformation] [nvarchar](max),
        [NumberOfPassengers] [int] NOT NULL,
        [ClientId] [int] NOT NULL,
        [BookingTypeId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.Bookings] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_ClientId] ON [dbo].[Bookings]([ClientId])
    CREATE INDEX [IX_BookingTypeId] ON [dbo].[Bookings]([BookingTypeId])
    CREATE TABLE [dbo].[BookingTrips] (
        [Id] [int] NOT NULL IDENTITY,
        [BookingId] [int] NOT NULL,
        [DriverId] [int] NOT NULL,
        [VehicleId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.BookingTrips] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_BookingId] ON [dbo].[BookingTrips]([BookingId])
    CREATE INDEX [IX_DriverId] ON [dbo].[BookingTrips]([DriverId])
    CREATE INDEX [IX_VehicleId] ON [dbo].[BookingTrips]([VehicleId])
    CREATE TABLE [dbo].[Drivers] (
        [Id] [int] NOT NULL IDENTITY,
        [LicenseNumber] [nvarchar](max),
        [LicenseExpiryDate] [datetime] NOT NULL,
        [LicenseTypeId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.Drivers] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_LicenseTypeId] ON [dbo].[Drivers]([LicenseTypeId])
    CREATE TABLE [dbo].[Employees] (
        [Id] [int] NOT NULL,
        [FirstName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [EmailAddress] [nvarchar](max),
        [IdentityNumber] [nvarchar](max),
        [Telephone] [nvarchar](max),
        [EmployeeTypeId] [int] NOT NULL,
        [GenderId] [int] NOT NULL,
        [TitleId] [int] NOT NULL,
        [NationalityId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.Employees] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Id] ON [dbo].[Employees]([Id])
    CREATE INDEX [IX_EmployeeTypeId] ON [dbo].[Employees]([EmployeeTypeId])
    CREATE INDEX [IX_GenderId] ON [dbo].[Employees]([GenderId])
    CREATE INDEX [IX_TitleId] ON [dbo].[Employees]([TitleId])
    CREATE INDEX [IX_NationalityId] ON [dbo].[Employees]([NationalityId])
    CREATE TABLE [dbo].[EmployeeTypes] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.EmployeeTypes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Genders] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.Genders] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Nationalities] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.Nationalities] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Titles] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.Titles] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[LicenseTypes] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.LicenseTypes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Trips] (
        [Id] [int] NOT NULL,
        [PickUpTime] [datetime] NOT NULL,
        [PickUpDate] [datetime] NOT NULL,
        [PassengerId] [int] NOT NULL,
        [DropOffLocation_Id] [int],
        [PickupLocation_Id] [int],
        CONSTRAINT [PK_dbo.Trips] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Id] ON [dbo].[Trips]([Id])
    CREATE INDEX [IX_PassengerId] ON [dbo].[Trips]([PassengerId])
    CREATE INDEX [IX_DropOffLocation_Id] ON [dbo].[Trips]([DropOffLocation_Id])
    CREATE INDEX [IX_PickupLocation_Id] ON [dbo].[Trips]([PickupLocation_Id])
    CREATE TABLE [dbo].[Locations] (
        [Id] [int] NOT NULL IDENTITY,
        [LocationName] [nvarchar](max),
        [DropOffTrip_Id] [int],
        [PickupTrip_Id] [int],
        CONSTRAINT [PK_dbo.Locations] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_DropOffTrip_Id] ON [dbo].[Locations]([DropOffTrip_Id])
    CREATE INDEX [IX_PickupTrip_Id] ON [dbo].[Locations]([PickupTrip_Id])
    CREATE TABLE [dbo].[Passengers] (
        [Id] [int] NOT NULL IDENTITY,
        [FullName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [Telephone] [nvarchar](max),
        CONSTRAINT [PK_dbo.Passengers] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Vehicles] (
        [Id] [int] NOT NULL IDENTITY,
        [VehicleColorId] [int] NOT NULL,
        [VehicleGroupId] [int] NOT NULL,
        [VehicleBrandTypeId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_VehicleColorId] ON [dbo].[Vehicles]([VehicleColorId])
    CREATE INDEX [IX_VehicleGroupId] ON [dbo].[Vehicles]([VehicleGroupId])
    CREATE INDEX [IX_VehicleBrandTypeId] ON [dbo].[Vehicles]([VehicleBrandTypeId])
    CREATE TABLE [dbo].[VehicleBrandTypes] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        [VehicleModelTypeId] [int] NOT NULL,
        CONSTRAINT [PK_dbo.VehicleBrandTypes] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_VehicleModelTypeId] ON [dbo].[VehicleBrandTypes]([VehicleModelTypeId])
    CREATE TABLE [dbo].[VehicleModelTypes] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.VehicleModelTypes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[VehicleColors] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.VehicleColors] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[VehicleGroups] (
        [Id] [int] NOT NULL IDENTITY,
        [Description] [nvarchar](max),
        CONSTRAINT [PK_dbo.VehicleGroups] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[BookingTypes] (
        [Id] [int] NOT NULL IDENTITY,
        [BookingTypeDescription] [nvarchar](max),
        CONSTRAINT [PK_dbo.BookingTypes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Clients] (
        [Id] [int] NOT NULL IDENTITY,
        [ClientReference] [nvarchar](max),
        [FirstName] [nvarchar](max),
        [Address] [nvarchar](max),
        [EmailAddress] [nvarchar](max),
        [Telephone] [nvarchar](max),
        CONSTRAINT [PK_dbo.Clients] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Quotes] (
        [Id] [int] NOT NULL,
        [DateCreated] [datetime] NOT NULL,
        [Price] [float] NOT NULL,
        [Discount] [float] NOT NULL,
        CONSTRAINT [PK_dbo.Quotes] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Id] ON [dbo].[Quotes]([Id])
    ALTER TABLE [dbo].[Bookings] ADD CONSTRAINT [FK_dbo.Bookings_dbo.BookingTypes_BookingTypeId] FOREIGN KEY ([BookingTypeId]) REFERENCES [dbo].[BookingTypes] ([Id])
    ALTER TABLE [dbo].[Bookings] ADD CONSTRAINT [FK_dbo.Bookings_dbo.Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
    ALTER TABLE [dbo].[BookingTrips] ADD CONSTRAINT [FK_dbo.BookingTrips_dbo.Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id])
    ALTER TABLE [dbo].[BookingTrips] ADD CONSTRAINT [FK_dbo.BookingTrips_dbo.Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
    ALTER TABLE [dbo].[BookingTrips] ADD CONSTRAINT [FK_dbo.BookingTrips_dbo.Bookings_BookingId] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Bookings] ([Id])
    ALTER TABLE [dbo].[Drivers] ADD CONSTRAINT [FK_dbo.Drivers_dbo.LicenseTypes_LicenseTypeId] FOREIGN KEY ([LicenseTypeId]) REFERENCES [dbo].[LicenseTypes] ([Id])
    ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.EmployeeTypes_EmployeeTypeId] FOREIGN KEY ([EmployeeTypeId]) REFERENCES [dbo].[EmployeeTypes] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Genders] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Nationalities_NationalityId] FOREIGN KEY ([NationalityId]) REFERENCES [dbo].[Nationalities] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Titles_TitleId] FOREIGN KEY ([TitleId]) REFERENCES [dbo].[Titles] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Drivers_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Drivers] ([Id])
    ALTER TABLE [dbo].[Trips] ADD CONSTRAINT [FK_dbo.Trips_dbo.Locations_DropOffLocation_Id] FOREIGN KEY ([DropOffLocation_Id]) REFERENCES [dbo].[Locations] ([Id])
    ALTER TABLE [dbo].[Trips] ADD CONSTRAINT [FK_dbo.Trips_dbo.Passengers_PassengerId] FOREIGN KEY ([PassengerId]) REFERENCES [dbo].[Passengers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Trips] ADD CONSTRAINT [FK_dbo.Trips_dbo.Locations_PickupLocation_Id] FOREIGN KEY ([PickupLocation_Id]) REFERENCES [dbo].[Locations] ([Id])
    ALTER TABLE [dbo].[Trips] ADD CONSTRAINT [FK_dbo.Trips_dbo.BookingTrips_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[BookingTrips] ([Id])
    ALTER TABLE [dbo].[Locations] ADD CONSTRAINT [FK_dbo.Locations_dbo.Trips_DropOffTrip_Id] FOREIGN KEY ([DropOffTrip_Id]) REFERENCES [dbo].[Trips] ([Id])
    ALTER TABLE [dbo].[Locations] ADD CONSTRAINT [FK_dbo.Locations_dbo.Trips_PickupTrip_Id] FOREIGN KEY ([PickupTrip_Id]) REFERENCES [dbo].[Trips] ([Id])
    ALTER TABLE [dbo].[Vehicles] ADD CONSTRAINT [FK_dbo.Vehicles_dbo.VehicleBrandTypes_VehicleBrandTypeId] FOREIGN KEY ([VehicleBrandTypeId]) REFERENCES [dbo].[VehicleBrandTypes] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Vehicles] ADD CONSTRAINT [FK_dbo.Vehicles_dbo.VehicleColors_VehicleColorId] FOREIGN KEY ([VehicleColorId]) REFERENCES [dbo].[VehicleColors] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Vehicles] ADD CONSTRAINT [FK_dbo.Vehicles_dbo.VehicleGroups_VehicleGroupId] FOREIGN KEY ([VehicleGroupId]) REFERENCES [dbo].[VehicleGroups] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[VehicleBrandTypes] ADD CONSTRAINT [FK_dbo.VehicleBrandTypes_dbo.VehicleModelTypes_VehicleModelTypeId] FOREIGN KEY ([VehicleModelTypeId]) REFERENCES [dbo].[VehicleModelTypes] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[Quotes] ADD CONSTRAINT [FK_dbo.Quotes_dbo.Bookings_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Bookings] ([Id])
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201905222152290_initialMigration', N'SiyayaTravelAssist.Migrations.Configuration',  0x1F8B0800000000000400ED5DDD6EDC3A92BE5F60DFA1D157BB838CDBC9B99909EC1924767210CC49EC8D9D83BD0BE46EDA118E5AEA95D4818DC53ED95EEC23ED2B2C2551127FAAF8274A6A7B1B0102B748168B551F4B145955FCDFFFFE9FB3BF3F6E93C54F921771969E2F5F9F9C2E17245D679B387D385FEECBFB3FFF65F9F7BFFDF33F9D7DD86C1F17BFB7F57EA9EAD1966971BEFC5196BBB7AB55B1FE41B65171B28DD7795664F7E5C93ADBAEA24DB67A737AFAD7D5EBD72B42492C29ADC5E2ECEB3E2DE32DA97FD09F1759BA26BB721F259FB30D490AF69C96DCD454175FA22D2976D19A9C2F6FE2A7E829BACDA39F2479571471519E5C576C1525E59B2C17EF9238A25CDD90E47EB988D2342BA392F2FCF65B416ECA3C4B1F6E76F44194DC3EED08AD771F2505616379DB57B71DD6E99B6A58ABBE614B6ABD2FCA6CEB48F0F52F4C4E2BB9B997B4979D1CA9243F5089974FD5A86B699E2FDF67D91F54CBCB85DCD7DB8B24AFEA81B2BEC872727249ABC7E909A3F06AA1D67BD5618542AAFAF76A71B14FCA7D4ECE53B22FF32879B5B8DEDF25F1FA1FE4E936FB83A4E7E93E49788E29CFB44C78401F5DE7D98EE4E5D35772CFC6F169B35CACC4762BB961D78C6BD30CF1535AFEF266B9F8423B8FEE12D2018213C74D49C7FC2B49491E9564731D9525C9D38A06A945AAF42EF5C5A47443A9ED8BB65B0AC55AF69FA3C7DF48FA50FE385FD23F978B8FF123D9B44F182BDFD2984E48DAA8CCF7C4D4DB25E5F1222715A76D5FD5A35B3ADB80515A714E454DF266728DCC3CEBF02ADF907CF4CEAEA3A72DD5E0FB2889B8B15D661495EEA262C42A1A53313E11A0DE6D3671350DA2E4537A9FE55B668E46EEF5CB7E7B47F2ABFBEBA82828196A4B4C13564FEF2289A9C8CCD3DE0A9F150967525FA29FF1432D3C84681EEFE820BF92A4AE54FC8877CD5BAC35B3DFC58A1FF36CFB354B7A0242F9F79B6C9FD7A8CE34956EA3FC8194EEACD628B7E0B4AE87334A8B8D7C56755CD96C94ADE5B0ADA232D794A07CB1625796FE6D9F957A99B11A2A437501CA4F530AB173B6EA5FF9360B810A12C317031595E382C0C68A0C354697794CD7ED43A9FC4E7EC4EB24BC390B67C95A6C6B2D593B3D6CB96C84A763B2A2FBBDADA6B0C895625393AFE26A2E9AB96860AEA904B356FFA763ACF9CF912D061623675D3D983956ACE5AFAD33C8B2B5EAF3366A0D81A33DD3F6F55BBC2669419A25DBE82B43D6DB87C75D9C3F559F36833F7318C5795675F66606B1839025B265F2C37697644F049ED08C665FA7E74E2A5226B25CEE6A67388DE85813AA29DC71A518837C954186A61792B7A96949BC4863A39F801FE3BC28AB3FC7371ED1441D7DA03A4DE8A7734E8AF13FD15B433D9105BE2509D9FDC8D229A4D8CC092FD32CD1A2EFB7CDF0E5F26D5C7A2C96E5CD8DA8D950A12A0BF7C2D1AC681D2CB9FC92C12CBDEB1B0635E57C85AE1BE1A300AEA1708A547365B88109C86A530433299729EC29155C19E3400372C795C32C8215143EE15AAECCD6D30464B32E8119948A14D6E4728829E7377603CCC16FEDAAF28B7C7387FB4CB824C59AAE55C7D93E361A207811EE6D7DE405A5C1487941B43545DEE06C081C61F9EC60E9F4A691A188BE8ABC4028BC76BC91C85139C2F1D9C1D17369210353BF00F142275B6778E3B26E7F44E4B343A4C32A524621B6CAF4C29FB003E58D428ECA118B0788C5E6231846A2F35624F2850DED56FA99C461C7B82FF6FCD6E05313AFFFF8B66B8E0F061E2734A4829C4C74DE2FA39C4B0C3F60D41D49082790F6332DDB5DDDDFFF96AD999B1164FB9B030FA922F70200CAD5B70054C9F598A2530FC86757FA5D39E7968A1439CAE5AE62AC20B8DF99A528D793842816C33294EA0C7B9B768CF8BF4A19891769C2021ED932318D7316629ADEA8F1E9602454EC5109952BB0042B394FED1AD66646F97A009F7D31CE265767D0ECE1AC91F7F4E9681CE78FFEC492927E590796231EEA69BD9CE055B5C3BB539E57D8BBD56B4E758E4CDE338A5138CE271B2FC48B2CC9427934FE9A67FB5D205AEFF328DDCCE81F64E94FA75B8ECB3E778E2E7F9D04405EE54A6D6FC2C4452B297CE3353DB9AF71A5E3BCAEA0E35AAC80712CD5F2E4B646AE8EDBBA828E5BB102C6AD546BD0AE830A93A116B32375349DF36D89C100AD8334C39A4399B20EFE5DA5EF3254A0B9A0A98D4D0C5D13CF390DDBF88176535EFA982DEC90B9CDE966E8DCEE481DE7F6016E7703B36A8AC988A0D966FE0E81355B1B0C85744DE608E7C385B316C5AEEB3F04ABC82A71083CD96270283C6B3247783E5378BA2EF81178229F0583824687AD07382A47706AFBE224350F4E19037621EA4FE6C06F5358E7E083F036C4DB1B9C0D81232EB57D35429A2E45C874B1425345EF4C1A2A34C736BF95E5302664C0EC8594AFC1CB54B0DC0BDE96A26EFF220DC574C986AEF37870169ECBB85867FB0A466E640625333024EEC0702BA6F5B0812D8554B68E6B36802016CE1B521CDC8774B3B08B6568A02EC74550DB40211BEF28482953E7CBD74B198C57E925352B2559BC5B57CCD1974254ACA38D2A673AB08D23739DF854E664C6FEA4F4C75E4B55BAB70BAA3B3ADFE2B454A7529CAEE35D945849496A6D3915ABB177FDC825976457B9ECA7A595246C1890E3265566BA3E2505992476B6E250A807A712C480691E8F68E875DEC6C24C02453C986F3210623299007ED8E86DBAEE836C67811C1CA880A9D910B5D0EB5A88819904818658CDC960A815D10458D4CAC1A67F29D47A1654CAC10A98D2D1C8855EDD2CDE65120CA2E1B893A10F11C804B843C66ED37397216016ACC9A1FE9872D10C2EBD72DB840232D864D5E2441D10737A72A252F6020D32B20940830CDFBFE7E9F0C287AF18B40BA6D531A14635085ABA007084001B1324870007E0633AEC00C2B5E95CCA60350B92807C5698C67539F47A8D0B912AF670D265CE72376E5E48C259980049B8706D3AEF934ACE0222300000D3B43E1A80331D5D58893D8AB44104FC820C40A7FA2EF3910017596064120A3308347E203A61CCE183C15DE80A551BE9A5E75237786D70988560074940767DC79844FDE07BFEB8889049BE18D0B036575578595D442013985C64DC363D0B119EF37C9D028180DA898145050E9C6F4820E1D8D34D8977B55957609656B364D17D37E171B5AE9636C48A851FDCC4EB157EF007FDD964E1FC8829DBC513B257BFEA833B894577F1A15698E582014631F8F6929C00C6F692B2610672B49F13E88087BA01323A77757BA48C0B6B5D2892C2E3B820C6C5351D76717138405608959B13B2924BAF010A987FAF0203E62E3E254CB1D8B389210A8B683A78C262708066175D3A272C25575E83EA31BF5E45F5CC4D7C4A5862418613C31216D174B084C5E000CB2E5079F66DDB565F36DF29CA1D1E41376E95886623A846F810929898F85B4812B003A0E6C69278BD8F41DDC8AD650A9A3CBEA7916B843C813A044EE020A7C31328089BEEB99BAA0E0250BAE349EDE5724638591826387A4145D37827941A46660093E319A57477E2AC7862CEE62685CB5701064191ECCEDE136D5DE047C58ED8FD84B0118569D3717F67E7AC6069FCBB4D6A956E690CF2FE921CC87B9ACCE57CE4DD60714C13424518F701ED03376EF9B44D495B90BC8D13DAED2EEFAA87E4118A36FB5610164652B0C01959ED15D11B522AD1327D14800C2505392009965B0823D32C7B0CA4BAD4B70A95D683C24080CBD1AC90E89DC12C89343BEB38A1E6DD6B20D6F82843645A27730381DEA73406B911DC850DB46A6F418808F3F43434E71C7F202282D3948913042D5630698FE64026BA633B0311FEAE67850A77966D20D387492B44BA6F473B127C2A0B8C16B7756D47B4DBD3D710E58E79EC88D65B5B1A826CD7D28E58BD21A121C6F69A2C8D10325261B56C20D52C04202AED92C940A07EA140EDD98B546ACE997FD806F199E7B9CAFA4B65E4F793755C56371AC5102AEF3CEB702A80A6424F780FD2AA1642522F2E51C5A38F0B120681460671EC77E65C230C34A0672431201766A8B2B008581106A20F59E14623BDA334B2D1879A8C2420E5FE065534DAA809610458DC04C77BFB9AD5C8010B77184902CA9D7CAA04B4BEFC02EF98373FC77BB790D38800F3DF1F5704C222059502EAA10E8D00F251F79305E495CE5112D75F832502DD09AC4AC4E4698DEEAA4BBED6DC38C42F068D5834DED566017B4804CE08AECAC4EC382C0C43EB3ACCEBB75FD76A84A27516E6AD1024DE2142E1B38F6B6482B912C383009C89FD2502B80F8F2010F84A08E09D62F42E165F093AFF62D330CC94207B8249D743284A0E6D551E5A5F63610098B731C73BFFF9A61105E6243C162CE43B2E1054E83C605555223EB0EE9840BC5E4782847AB98BFEED623019A84BECD037CBD8F6C22677A52A1957A74F61780E6E9FDC80813D038D081DBC35D53EF8B187123094D81695ABC9C7101AAAC6CBD0658496A471E10594999C8A129597CEC10D1A10E2E2A60EA6DD4C32CB08F14C1B553E722E44543E3A4F2B683088AF953A98767FCC2C1FC4456A1CF9801706E8ED3BE8F0835A65D9E567A895979D7C46158BE89482CB45E3BCA2750AC05645FD718E592AB0C38AA598038806F902377A6168C7827C837BC905F90A17B79A8389A5DD5CC62502F911D87812F8CA41F21DE0C8745BE4C146CFB6C6F1C103E7E21627E3BE4317CFC2392AEDDEBEF5C0DBF46ADD396E5776B6BA59FF20DB883D385BD12A6BB22BF75152AFA98AB6E073B4DB559CF72DD993C5CD2E5A5727167FBE592E1EB7495A9C2F7F94E5EEED6A55D4A48B936DBCCEB322BB2F4FD6D976156DB2D59BD3D3BFAE5EBF5E6D1B1AABB56077E453E7AEA732CBA3072295D2AE29A77592CCCBA88CEEA22ADBDDC566AB54134EAD91D393B62BE9605A55567BAAD236A8FE6E1A018913AFAB8C884559650BED4EB4D5437E46EA231DE3B6F210A8D394AAE0515BD2B637EB28897220D7215DAFECB729EE3380B766DDDD9451B92F444252913D4D217B224F512870E691CBC50AB0C9953A53BECAEBE371802A2BB1A7781D3D556A7D4F8B144EE53267AACD8B0C20099D365AD083B42E15D9D37CB7D9C4CD89CBA7F43ECBB76C5B82A78D54B1EFE3CB7E7B47F2AB7B7E4B86EF002AB7A7DEFB65F134716F2D23AE5A9F40005898BB60659D2513219BA5956297A437846CE75CAC20B63C1C6A09A11D177B6B08B71ED522227A73A3D5671D11CC209A8B04A7C4B9C0F3A4349EF1B321A93D24090822F834C8023F58C371A0C34ECD1A2B2412928A9C697E78DCC5F95373F93640972F76A60D992943E6A5D9C0A53B37F7861776126D0130BCE93810E3D2C4F344B8C70EEA8F2052FD537B4A62AA779E9A58624FB14DD30FCD25B9CC9E2A97259E27C83D7619B3988B581CB53E4F314EB54F34CBD3C3D3CF6AC6DAE66B14468A2571C4E948994685E59658747046023BBB186C28A0AD22076301371FC7600897AA08AB10BEE06054D77ABD05541AF37E765717D6F0A828223BE2055417EF65EEAE336DEBA3E248E7321850638D4BBFBBAE9076472D11C9012FA0AE34EE86161AD3B63EEA8DB49E1C212797DFC6C9943B2695AFCFB75D73398EB095C83D77A5A67EE9F2CF5D763AB93C84E23EA72641E17CD3BE738A0A39E711E72F9B098F361D690785F5077C960A2507A3306EA739A0C6FAA030779569DA8EB425B14F126047A27B3AC78684CF87FE4C08D238F278E307F17FB1400FDA721CECC819AC80BD6D34BB95916A978008A08A262732521512C10194B589E2E64699D6A57328DCFA90516FDC69481CD6F2D2001221C12500126D02CCB941C279E58607491F02EC0D120D89C302C9BC6A64EEAEE155D8045D7BAB0F697E541D913D71C3ABAE0971F7561DD2FCA83A22396B06D49CC63BD54271DAD6E3E88DEB12552156E760B4D9FA9D065424EC546BA143ACE138EA532E3E579DA1BC7CED429E5C8347CD1EA7CCE1CFAD9FD1872773300E8870D073DA02E048BB915E2B81BD53D9FDDEC2DE62F3C881A7EE7E6F81A1EEE9F49811BDCCE14D4A3176DD793B526C6EBBF358B9D0239B865098BA2A382B48F194E0246C1C1B9E1CA2F9E7BC41AFE5EA224B1BEFDBC5A7A2BA37BEBB33DE7EDC72F0813F72F8007F77E0F0AD43E0460DE6F7540A4728246AD4CC0507051AEDA8076306CE81E0747EA636B7392E0334A24B7730CCD274D402E04697DEE1A080631E7B18F4C8A912DCC023B71E821D382DC2206B131C39700E8883028E71E466DC28D17272956E85C59E74BFBB683916A92684D0D572A902E26A79142C6A4E0E5D6BAA2C1754083FE34D15B676F34421B73DA92A9CDCFC47D28668B6153E47697C4F8AF236FB83A4E7CB37A7AFDF2C17EF92382A9AE0451694F756CED26A15A5F7FA972A4A8F6CB62BB9B97BAC5F45A528360910E957CD3A718B408ACFFB0751D0609312F76C25373C0340D924478C2BA1D613F85742755EADF5AFA3B22479DABB152F1715EEA2BB2A4A93616FA5252F05CA353DA53FA37CFD23CAFF651B3DFE2B4FB24E956BA0287C8A34F436F44759BB52F871C77DB30760500C8F0B40508E8D6B48DE2759543A8F58088A0BC75B40FD22817001284311701CF41D25D9C7BE7134944CD09FD20D793C5FFE67DDE8EDE2D3BF7F6FDBBD5AD40879BB385DFC972F70DB5332370E84C60E6CF0DFCD36260CB85AF3999B316F590F54771F15E7D67BDB6E50E75C1C9D5BEF5DC33130065E37FF5CE12545C005B07540ECDBC077A514F5E60605A1F118708063CD260384850806CE42EE2C20043CA280C4C4F3800004E520B60024B9438620231663D8DC9020B61E848A3EF8CD8D85B6DDA0CEBB8039B7BE59B3415D4BD1756E0C088DC73446EAC9F2B37D430927D1CE33C85A725058D951667A99A1615D47C1E90507C4581D45A617191AE474149C016BF37D0B8FBF36E58399067E65F0914C4349F1514C6EF2E09A0EFC6E570F715CBFE0650A184356BB75EAD980A3606402F6DCD8DB18F094FAD91A1831382BC406B8E487E00528D67A38983CD9101A8F002224D2EBD9A2A80F193BB4AFFF215FD6D6EA846F297FAECA94A3B7BCB65559EB105BBB5DC0971723AC75084684F8302F66380A637CD9EB43B19E2D20872D8251750A915C5EEAE4288CA84E2468EAFFA93A5DA507C42C1D256725392064E82839BBA3E5973359B1709FF16408C5CC3C5BF1295137015E5F61CFDA429E8C053F6A9B64F50EC4B0BCA0DDAF900E692C3A668887571F19634F05D324E7280A1C6D6117B5223712B70C01B7B77FDE2765BC4BE235E5E17CF95AF118BE4A2F294E4BB278B76E3C372FA2621D6D545954DEB3265E403E641EFEA4906626A68CA3E4224B8B328F6235B288EA2F5DC7BB2881C62F55B6447C35AA8EAC5C724976D589595ACA63B4E9CB9489F56CD59197A46C9285E062AC0794FE6668E53E674179EDA3170B1F343DE7BCC0C153EE4E02198B0BB4E1BBAE05D509CF5F2C82F41943E785912145F22458BAD5DD382EDF142E288E3D79B1C8014EC70F0033B75892EE49D0A2BD9D5DB9485CD056FB48C68BAC2B4FA59F9E9CA8B4BCF48EDE2731AFE2E7D639EEF9C0DD80CDDF6ACF294D786E0F006B14059AF1FAFCB7C1D5EF0034C38D1B93E080BFC512743E0F3CFDF9200A9E92F07C141C4C6701F41720A9DDE1B7034D0201303B03BA62901507690C34DB9C4111C2725B6BD23D1CE7BD6FAB8C81BAD764DE85146FCA3931A5FAB91C0B47ED4FA07D63EA88293E14A05C094134674081159242AD005CB43210010E46DF260BC40410E87C8ABE0399EC398DF5BE47BCDAB8A7937C334E891B5D4EEEF980A34D633F9DD19072641C6DC614AAB749FF31F1478376BDE0B1DA1F0C80707B06AEEBF8A960309BDE65C722C53D0D7F7B283E49BC1AD5C249DE258ADB1BC01357388A9DB1C8911D1C6816C9DBD53E6DD2984F09C28EFB168446ECF9E9795CEC41AC8C8B3437AD87419A0BC0B497294C09B0DA01D01A5C8DBB20A04D56F0B24185E5873F0440A1B7894C09A6DA27D21A4C8D0725A04556F0B2C18465AC3F0430A197C84CBEEE866347BCD47798FBF52EDA9978C39ECB1D34270EBE737CE336A5CDBC0768EF7900014C1D781840E012681D041074C7B87C1D48818EC7B80EB00A8B83A9D6AE2EB09312D7CD8A05D00FBED75B9B6794535BFBE890958F5EA531ABDEFB6C89B3AA1CF2440FFE02683AE189B027236FBF4DA173EC1A8BD9F6DE3E88998A5BB8C95985159DB314D5223E968BDE0F5ED67F9397F87CB9B9CBA86E1B577A56A8DC8282D16FDEFD581F2C693FDE4FB37C31F5D5BA9A28DDB405500F4D999978EF7FA690EF8BA00E7A174BDB2E9AF72CDA4D53ACEBAAD9673575D73A912B1DB50550174D9999B8E064ACF4209442DDF415628B91308F54A51BF61CEAE0B6B9F0DE4459706053E80BA5502FC285EDC651C073049F1C76B3A23F4953F9EFD3D743CC77D74E9BBAE04E78953EB832A8133E25B1A197EED354E9A32B817AE876542CE973DBBC58475C154D8FDC918765D7DCE906D6355745D3357759A765D76C0F12EB96156BBA64174B5A76C776A9B0EE58B1A63B7619A2EDEB0796A950AA7BFD5849B25D232BDDB405500FED957226E26C21A5D066CF21D2EC2A2F99B27807823EBA6DC15506DE4258F880B02884DE6AF515196281B26282FCC181D6EA86A538408BC12B9158C0B0F5D15A02BBE27BB566B67D34E320E1D82160A416414602E3C09BBEE65D783EE3C0E5401760C8DA5818815961A5D15CF4D23C997180726C0630406DF886C0ACB886AE596D1FCD3F4461BD858E52E3CD8F852C705C0BCF3543B61694C770018F7B60B826BFFC007A05BEDE840B64EBE783870BDFFDA70ED8EC852ECE55996B885D1113D25259BC3B2EE040F9BBEA34E3C4DCAD0F7C98F0ED6A80D9357A16FBB3ED2E228F81CA7EB1C018B5AEB30293CA4754CD29F774860182579D218AD4797B1EB81E15674583B535CC480FAB39C9302D7CF38081BB7AF40943C13E6CF9FBE3B9428D50B0AF739E1257184A58800F192E2393C359B80141942002E10421F93AE142D03945416C0B3B0F3CEFAC60EE814B7E39F8C0750E3C10DBC21E08CF3B2B986DE0900F89C122229E187E2CCFB00405DD25F0316BDC2AE0733595F1031C34F25965F4200059972D9AF0DC3C741B910D1872BB25878F163E4D064EC9393EDB47B30F8FED0AE2A3034F33030057D8A6AC5BB127D64353AE60EDCACE56CD2E277B407F2A57AD9EADBEEED32AFF58F3EB9214F1434FA2BA4636256BE120B5AB53DDB9D89EE54A1CB555A47C639F49196DA2327A9797F17DB42E69F19A14452DA2DFA3645FEF8BDC91CDA7F46A5FEEF6251D32D9DE25C26E58752EACEBFF6CA5F07C7655E7492C420C81B2195729DBAED2F7FB38D9747C7F0432A52124AA036796D5B0D2655965377C78EA287DA933ECD91062E2EBCEC96FC976975062C5557A13FD243EBC7D2BC86FE4215A3F5DB31B737122664588623FBB8CA3873CDA168C46DF9EFEA418DE6C1FFFF67F60490FA0724A0100 , N'6.2.0-61023')
END

