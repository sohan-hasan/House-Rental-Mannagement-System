USE [HouseRentalManagementSystem]
GO
SET IDENTITY_INSERT [dbo].[ApartmentBuildings] ON 

INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (1, N'PRIYALOY', N'PRIYA BUILDERS LTD', N'A Highly Secure Building. Always, caretaker facility.', N'102/1, Noyatola, Moghbazar, Dhaka.', N'Shorif', N'01751050039', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Bui', N'74e5d4ff-6147-4330-9180-566001d6264e_AKH-ECO-Apparels-at-Dhamrai-Bangladesh_Q320.jpg')
INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (2, N'Optech', N'Optech Byte Ltd', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'104/3, Barodhara, Dhaka.', N'Mohon', N'01677672824', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'f121fd05-1681-4c47-b79e-8457a1f433a7_building-1.jpeg')
INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (3, N'Beekites', N'Beekites techonology Ltd.', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'12, Panthopath, Dhaka', N'Arif', N'01823587692', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'4b0e55aa-c894-49cb-8842-e1c53a7a1092_c87a7744.jpg')
INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (4, N'Prince House', N'Prince House Opera', N'
A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'102/1, Noyatoal, Moghbazar, Dhaka', N'Shorif', N'01677672824', N'
A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'fe4d9e5a-0f7a-4a97-a131-1587ad99a0a8_images.jpg')
INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (5, N'Home', N'Home Ltd', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'104/3, Barodhara, Dhaka.', N'Mohon', N'4536475', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'dea4cff0-1357-40b0-b6de-df6384a4ebfa_building-1.jpeg')
INSERT [dbo].[ApartmentBuildings] ([BuildingId], [BuildingShortName], [BuildingFullName], [BuildingDescription], [BuildingAddress], [BuildingManager], [BuildingPhone], [OtherBuildingDetails], [ImageName]) VALUES (6, N'Beekites', N'Beekites techonology Ltd.', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'12, Panthopath, Dhaka', N'sdf', N'01823587692', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'1786f19c-7927-4b01-bba4-eb0fc9d24753_download.jpg')
SET IDENTITY_INSERT [dbo].[ApartmentBuildings] OFF
GO
SET IDENTITY_INSERT [dbo].[RefApartmentTypes] ON 

INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (1, N'Studio')
INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (2, N'Micro')
INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (3, N'Garden ')
INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (4, N'Basement')
INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (6, N'Maisonette')
INSERT [dbo].[RefApartmentTypes] ([AptTypeCode], [AptTypeDescription]) VALUES (7, N'Stadium')
SET IDENTITY_INSERT [dbo].[RefApartmentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (1, N'HRM-1', 1, 1, 2, 3, 4, CAST(10000.00 AS Decimal(16, 2)), CAST(20000.00 AS Decimal(16, 2)), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (2, N'HRM-2', 1, 2, 1, 2, 3, CAST(15000.00 AS Decimal(16, 2)), CAST(25000.00 AS Decimal(16, 2)), N'A Highly Secure Building. ')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (3, N'HRM-3', 1, 3, 3, 4, 6, CAST(50000.00 AS Decimal(16, 2)), CAST(80000.00 AS Decimal(16, 2)), N'A Highly Secure Building.')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (4, N'OP-1', 2, 2, 3, 4, 5, CAST(40000.00 AS Decimal(16, 2)), CAST(60000.00 AS Decimal(16, 2)), N'A Highly Secure Building. ')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (5, N'BK-1', 3, 4, 2, 3, 4, CAST(10000.00 AS Decimal(16, 2)), CAST(240000.00 AS Decimal(16, 2)), N'A Highly Secure Building. Always')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (6, N'Bk-1', 3, 4, 2, 3, 4, CAST(80000.00 AS Decimal(16, 2)), CAST(100000.00 AS Decimal(16, 2)), N'A Highly Secure Building. Always')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (7, N'D-24', 1, 1, 3, 3, 4, CAST(30000.00 AS Decimal(16, 2)), CAST(40000.00 AS Decimal(16, 2)), N'A Highly Secure Building. ')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (8, N'D-24', 3, 2, 3, 0, 0, CAST(0.00 AS Decimal(16, 2)), CAST(0.00 AS Decimal(16, 2)), N'as')
INSERT [dbo].[Apartments] ([AptId], [ApartmentName], [BuildingId], [AptTypeCode], [BathroomCount], [BedroomCount], [RoomCount], [MonthlyRent], [SecurityDepositAmount], [OtherApartmentDetails]) VALUES (13, N'sdf', 2, 2, 0, 0, 0, CAST(0.00 AS Decimal(16, 2)), CAST(0.00 AS Decimal(16, 2)), N'sdf')
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[RefBookingStatuses] ON 

INSERT [dbo].[RefBookingStatuses] ([BookingStatusCode], [BookingStatusDescription]) VALUES (1, N'Confirmed')
INSERT [dbo].[RefBookingStatuses] ([BookingStatusCode], [BookingStatusDescription]) VALUES (2, N'Provisional')
SET IDENTITY_INSERT [dbo].[RefBookingStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Tenantes] ON 

INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (1, N'Sohan', N'Hasan', N'01751050039', N's.pairet21@gmail.com', CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2), N'1', N'Job Holder, Honest Person', N'afa8ae4f-8e47-41bd-afad-789f730bbb7c_29062.jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/afa8ae4f-8e47-41bd-afad-789f730bbb7c_29062.jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (2, N'Shakil', N'Mahmud', N'01677672824', N'shakil@gmail.com', CAST(N'2021-11-02T00:00:00.0000000' AS DateTime2), N'1', N'Job Holder, Honest Person', N'4c9626b3-0f4e-4253-82f6-98195d9dbaca_IMG_6135.JPG', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/4c9626b3-0f4e-4253-82f6-98195d9dbaca_IMG_6135.JPG')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (3, N'Sanjida', N'Hasan', N'01677672824', N'sajid@gmail.com', CAST(N'2021-11-16T00:00:00.0000000' AS DateTime2), N'0', N'Job Holder, Honest Person', N'd93b3718-8d4f-4994-a06f-e532b4336287_10034.jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/d93b3718-8d4f-4994-a06f-e532b4336287_10034.jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (4, N'Rifat', N'Mia', N'01677672824', N'rifat@gmail.com', CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), N'1', N'Job Holder, Honest Person', N'2dcc551a-8409-402a-a359-8b23f9f1a043_download (1).jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/2dcc551a-8409-402a-a359-8b23f9f1a043_download (1).jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (7, N'Suvrotoo ', N'Dash', N'01752040039', N'suvrotoo@gmail.com', CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), N'1', N'Job Holder, Honest Person', N'a2137c23-e925-433e-9f43-af0da9d36f7f_10034.jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/a2137c23-e925-433e-9f43-af0da9d36f7f_10034.jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (8, N'Jenny', N'Osmita', N'02937383393', N'jenny@gmail.com', CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), N'0', N'Job Holder, Honest Person', N'bbfde7f3-e20f-49af-82b2-259c3885816c_02.jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/bbfde7f3-e20f-49af-82b2-259c3885816c_02.jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (9, N'Shakil', N'Mahmud', N'01751050039', N'shakil@gmail.com', CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), N'1', N'asfd', N'246916cc-8445-4534-bf68-5d5f825da85d_IMG_6135.JPG', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/246916cc-8445-4534-bf68-5d5f825da85d_IMG_6135.JPG')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (10, N'Sajid', N'Hasan', N'01751050039', N'sajid@gmail.com', CAST(N'2021-11-29T00:00:00.0000000' AS DateTime2), N'1', N'He is a good person.', N'8ac67c28-db41-4ec7-ab64-45e54e172e35_images (1).jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/8ac67c28-db41-4ec7-ab64-45e54e172e35_images (1).jpg')
INSERT [dbo].[Tenantes] ([TenantId], [TenantFirstName], [TenantLastName], [Phone], [Email], [DateOfBirth], [GenderCode], [OtherTenantDetails], [ImageName], [ImageFullPath]) VALUES (11, N'Sohan', N'Hasan', N'01751050039', N's.pairet21@gmail.com', CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), N'1', N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.', N'231078a3-9967-417d-8725-6ed5fb3ac8ec_29062.jpg', N'F:\SOHAN\EidUlAzaha\Final-Project\AngularJs\HouseRentalManagementSystem5\HouseRentalManagementSystem\HouseRentalManagementSystem\wwwroot\images/tenant_images/231078a3-9967-417d-8725-6ed5fb3ac8ec_29062.jpg')
SET IDENTITY_INSERT [dbo].[Tenantes] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentBookings] ON 

INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (2, 1, 2, 2, 1, CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (3, 2, 4, 2, 1, CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (4, 2, 4, 2, 2, CAST(N'2021-11-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-19T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (5, 3, 5, 4, 1, CAST(N'2021-11-16T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (6, 1, 3, 1, 1, CAST(N'2021-11-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (7, 2, 4, 3, 1, CAST(N'2021-11-30T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (8, 3, 5, 2, 1, CAST(N'2021-11-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-10T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (9, 1, 1, 1, 1, CAST(N'2021-11-16T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-11T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (10, 1, 1, 1, 1, CAST(N'2021-11-18T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-12T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (11, 1, 3, 1, 1, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-16T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (12, 2, 4, 2, 1, CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), N'A Highly Secure Building. Always, caretaker facility.Earthquake tolerant Building.')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (13, 2, 4, 2, 1, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-08T00:00:00.0000000' AS DateTime2), N'sfds')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (14, 1, 1, 2, 2, CAST(N'2021-12-21T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-11T00:00:00.0000000' AS DateTime2), N'dfs')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (15, 2, 4, 1, 2, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), N'sdf')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (16, 1, 1, 2, 1, CAST(N'2021-12-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), N'dfs')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (17, 2, 4, 2, 1, CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), N'sadffa')
INSERT [dbo].[ApartmentBookings] ([AptBookingId], [BuildingId], [AptId], [TenantId], [BookingStatusCode], [BookingStartDate], [BookingEndDate], [OtherBookingDetails]) VALUES (18, 2, 4, 2, 2, CAST(N'2021-12-15T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-01T00:00:00.0000000' AS DateTime2), N'zxfcz')
SET IDENTITY_INSERT [dbo].[ApartmentBookings] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [JsonData], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'899d4010-dcf1-4b8b-90d1-a1c57ab34214', NULL, N'Editor', N'EDITOR', N'e0f9bf03-e921-4a05-a720-efe7b76ddd9a')
INSERT [dbo].[AspNetRoles] ([Id], [JsonData], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b69063e9-bb74-4a04-92a3-98af979ad6d4', N'[{''controller'':''Home'',''action'':''index'',''text'':''Dashboard'',''class'':''fa fa-th'',''child'':[]}', N'Admin', N'ADMIN', N'4b959b13-2d15-455e-8552-4622640d0bc9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [ImageName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6e790339-7a71-402c-a1c6-cfb4524a604e', N'Abid', N'Hasan', N'af1a3a5c-8db8-4b66-8ad3-7fb111495aa5_images.jpg', N'abid', N'ABID', N's.pairet21@gmail.com', N'S.PAIRET21@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMLU/o6OxikcdEovhBmwYJ5Snxqd62b/SeswWizIQLG+bHfR3n6NMOqYDP0tlOk75Q==', N'UVMD5BGVEVNG3EB2UHNMGK6AVQXYFBLI', N'a0bc1991-3635-4141-b033-af9fb31cf332', N'01751050039', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [ImageName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e80ff53f-2ba7-4051-8085-a10f16af74e6', N'ADMIN', N'ADMIN', N'ADMIN', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKWu8AGyA7Wdfl9iKm3Lhdu7WdKULI6dxS9Bz/H3wmZMDgPyfV3CoyS6vJy2ZAonMg==', N'GM3CUQLBHQ3YHZMEBCANWPDM3SYGGITQ', N'ee9a4b82-e22e-456f-8a5f-d780d6cd5fc4', N'+8801677672824', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e790339-7a71-402c-a1c6-cfb4524a604e', N'b69063e9-bb74-4a04-92a3-98af979ad6d4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e80ff53f-2ba7-4051-8085-a10f16af74e6', N'b69063e9-bb74-4a04-92a3-98af979ad6d4')
GO
SET IDENTITY_INSERT [dbo].[RefApartmentFacilities] ON 

INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (2, N'24 hour electricity ')
INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (3, N'AC')
INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (4, N'Caretaker')
INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (5, N'Parking')
INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (6, N'Basement')
INSERT [dbo].[RefApartmentFacilities] ([FacilityCode], [FacilityDescription]) VALUES (9, N' 24 Hour Water Avliable')
SET IDENTITY_INSERT [dbo].[RefApartmentFacilities] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentWiseFacilities] ON 

INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (8, 1, 2, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (9, 1, 3, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (10, 1, 4, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (11, 1, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (12, 1, 6, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (14, 2, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (15, 2, 3, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (16, 2, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (17, 2, 5, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (18, 2, 6, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (20, 3, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (21, 3, 3, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (22, 3, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (23, 3, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (24, 3, 6, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (32, 4, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (33, 4, 3, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (34, 4, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (35, 4, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (36, 4, 6, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (38, 5, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (39, 5, 3, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (40, 5, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (41, 5, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (42, 5, 6, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (44, 6, 2, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (45, 6, 3, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (46, 6, 4, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (47, 6, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (48, 6, 6, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (67, 7, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (68, 7, 3, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (69, 7, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (70, 7, 5, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (71, 7, 6, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (73, 8, 2, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (74, 8, 3, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (75, 8, 4, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (76, 8, 5, 0)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (77, 8, 6, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (87, 13, 2, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (88, 13, 3, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (89, 13, 4, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (90, 13, 5, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (91, 13, 6, 1)
INSERT [dbo].[ApartmentWiseFacilities] ([ApartmentWiseFacilityId], [AptId], [FacilityCode], [IsChecked]) VALUES (92, 13, 9, 0)
SET IDENTITY_INSERT [dbo].[ApartmentWiseFacilities] OFF
GO
SET IDENTITY_INSERT [dbo].[RefPaymentTypes] ON 

INSERT [dbo].[RefPaymentTypes] ([PaymentTypeId], [PaymentTypeDetails]) VALUES (1, N'Bkash')
INSERT [dbo].[RefPaymentTypes] ([PaymentTypeId], [PaymentTypeDetails]) VALUES (3, N'Cash')
SET IDENTITY_INSERT [dbo].[RefPaymentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingPayments] ON 

INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (1, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(40000.00 AS Decimal(16, 2)), 2)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (2, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(16, 2)), 3)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (3, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(250000.00 AS Decimal(16, 2)), 5)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (4, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(130000.00 AS Decimal(16, 2)), 6)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (5, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(250000.00 AS Decimal(16, 2)), 8)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (6, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(16, 2)), 7)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (7, 1, CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(30000.00 AS Decimal(16, 2)), 9)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (8, 1, CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), CAST(30000.00 AS Decimal(16, 2)), 10)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (9, 3, CAST(N'2021-12-02T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(16, 2)), 12)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (10, 1, CAST(N'2021-12-02T00:00:00.0000000' AS DateTime2), CAST(130000.00 AS Decimal(16, 2)), 11)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (11, 1, CAST(N'2021-12-03T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(16, 2)), 13)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (12, 1, CAST(N'2021-12-03T00:00:00.0000000' AS DateTime2), CAST(30000.00 AS Decimal(16, 2)), 16)
INSERT [dbo].[BookingPayments] ([PaymentId], [PaymentTypeId], [PaymentDate], [PaymemtAmount], [AptBookingId]) VALUES (13, 1, CAST(N'2021-12-03T00:00:00.0000000' AS DateTime2), CAST(100000.00 AS Decimal(16, 2)), 17)
SET IDENTITY_INSERT [dbo].[BookingPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentImages] ON 

INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (1, N'bf80ab6d-0a82-4908-9daa-ee50c5ea83fc_bathroom-1.jpg', 1)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (2, N'311504da-ed83-43f3-bfff-9cc4f7cba8bd_bathroom-2.jpg', 1)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (3, N'4b7be40b-5272-46d3-9db0-a40221c05797_becony-2.jpg', 1)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (4, N'4aaad5ff-b1fd-4ce2-a80b-fe283fbcb17e_room-2.jpg', 1)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (5, N'ddbdeb37-9b5a-459e-a90c-67b9e2c68029_room-3.jpg', 1)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (6, N'74d71b2f-033e-4168-9885-18eb9b7183ce_bathroom-1.jpg', 2)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (7, N'e56d0854-9dcc-4a4f-ad6a-cac2fd9a5432_room-2.jpg', 2)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (8, N'b3533807-7628-47bb-bbcc-92903b4122d5_becony-2.jpg', 3)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (9, N'ab5edcb0-e3ba-41ef-a952-5205b3ac0ecb_becony-3.jpg', 3)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (10, N'39c14cad-4448-4658-8eea-52a110708c33_becony-4.jpg', 3)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (11, N'fb580319-9ffd-4021-9283-905d7c16f1aa_bathroom-1.jpg', 4)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (12, N'27038a03-daf0-48e4-a761-051009119fb8_becony-2.jpg', 4)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (13, N'74c771fd-0dd7-4239-b917-3eac2f5121c4_becony-3.jpg', 4)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (19, N'6dd84ddb-8e83-4afb-80d8-edd86f691294_550d19_2a7881ee1a6741c39fd34fa4e285a2d8_mv2.jpg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (20, N'55a6e516-ba29-4b45-83f4-fa3c5e55287d_AKH-ECO-Apparels-at-Dhamrai-Bangladesh_Q320.jpg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (21, N'd25d08ab-d2ff-4277-b276-864600c13849_building-1.jpeg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (22, N'425b5888-0a79-46d3-80a9-0aed9aa37a3c_c87a7744.jpg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (24, N'cfdaaa52-0509-4be4-8846-a89a8ba97068_building-1.jpeg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (25, N'fde7ed47-d0ab-425b-96f4-d631c6e814ca_c87a7744.jpg', 7)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (26, N'00a85582-7fac-4a30-8a04-9833bd7525cb_building-1.jpeg', 8)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (43, N'65c0ca92-e091-4023-80a8-37a6521667c3_10034.jpg', 13)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (44, N'0a771c3a-dd03-491e-8eff-5b4df589ae94_29062.jpg', 13)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (45, N'450617e1-29a0-462e-9f73-ffa64e61c7cf_download (1).jpg', 13)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (46, N'4ace3c76-9d9d-482f-9d2d-91b9857beb34_download.jpg', 13)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (47, N'047398fa-9b42-4efc-adbb-57b703a87f6a_images (1).jpg', 13)
INSERT [dbo].[ApartmentImages] ([ImageId], [ImageName], [AptId]) VALUES (48, N'ca9514a0-ca20-44c8-9f2a-f1dc4764aca4_images.jpg', 13)
SET IDENTITY_INSERT [dbo].[ApartmentImages] OFF
GO
SET IDENTITY_INSERT [dbo].[ViewUnitStatuses] ON 

INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (2, 2, 2, CAST(N'2021-11-21T10:41:52.5824531' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (3, 4, 3, CAST(N'2021-11-21T10:42:48.1142764' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (4, 4, 4, CAST(N'2021-11-21T10:45:16.9501926' AS DateTime2), N'YES')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (5, 5, 5, CAST(N'2021-11-21T10:48:00.9536066' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (6, 3, 6, CAST(N'2021-11-21T10:48:59.6355528' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (7, 4, 7, CAST(N'2021-11-21T11:42:27.7572085' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (8, 5, 8, CAST(N'2021-11-21T11:41:22.0773610' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (9, 1, 9, CAST(N'2021-11-21T11:43:41.6566231' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (10, 1, 10, CAST(N'2021-11-22T23:22:52.8866113' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (11, 3, 11, CAST(N'2021-12-02T12:11:14.9089277' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (12, 4, 12, CAST(N'2021-12-02T12:10:45.2860708' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (13, 4, 13, CAST(N'2021-12-03T01:22:36.7591183' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (14, 1, 14, CAST(N'2021-12-03T01:23:04.5132536' AS DateTime2), N'YES')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (15, 4, 15, CAST(N'2021-12-03T01:23:26.4688129' AS DateTime2), N'YES')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (16, 1, 16, CAST(N'2021-12-03T01:27:29.9667044' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (17, 4, 17, CAST(N'2021-12-03T01:30:45.7858013' AS DateTime2), N'NO')
INSERT [dbo].[ViewUnitStatuses] ([StatusId], [AptId], [AptBookingId], [StatusDate], [AvailableYn]) VALUES (18, 4, 18, CAST(N'2021-12-03T01:31:29.0095505' AS DateTime2), N'YES')
SET IDENTITY_INSERT [dbo].[ViewUnitStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[SecurityDeposites] ON 

INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (1, CAST(N'2021-11-25T00:00:00.0000000' AS DateTime2), CAST(25000.00 AS Decimal(16, 2)), 2)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (2, CAST(N'2021-11-17T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(16, 2)), 3)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (3, CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2), CAST(240000.00 AS Decimal(16, 2)), 5)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (4, CAST(N'2021-11-09T00:00:00.0000000' AS DateTime2), CAST(80000.00 AS Decimal(16, 2)), 6)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (5, CAST(N'2021-11-10T00:00:00.0000000' AS DateTime2), CAST(240000.00 AS Decimal(16, 2)), 8)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (6, CAST(N'2021-11-24T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(16, 2)), 7)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (7, CAST(N'2021-11-11T00:00:00.0000000' AS DateTime2), CAST(20000.00 AS Decimal(16, 2)), 9)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (8, CAST(N'2021-11-12T00:00:00.0000000' AS DateTime2), CAST(20000.00 AS Decimal(16, 2)), 10)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (9, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(16, 2)), 12)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (10, CAST(N'2021-12-16T00:00:00.0000000' AS DateTime2), CAST(80000.00 AS Decimal(16, 2)), 11)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (11, CAST(N'2021-12-08T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(16, 2)), 13)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (12, CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), CAST(20000.00 AS Decimal(16, 2)), 16)
INSERT [dbo].[SecurityDeposites] ([DepositPaymentId], [ReturnDate], [DepositAmount], [AptBookingId]) VALUES (13, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(60000.00 AS Decimal(16, 2)), 17)
SET IDENTITY_INSERT [dbo].[SecurityDeposites] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211121030104_init', N'5.0.11')
GO
