USE master
GO
IF DB_ID('HouseRentalManagementSystem') is not null
DROP database HouseRentalManagementSystem
GO
CREATE DATABASE HouseRentalManagementSystem
GO
USE HouseRentalManagementSystem
GO
CREATE TABLE [dbo].[Apartment_Buildings] (
    [building_id]            INT           IDENTITY (1, 1) NOT NULL,
    [building_short_name]    CHAR (15)     NOT NULL,
    [building_full_name]     VARCHAR (80)  NOT NULL,
    [building_description]   VARCHAR (255) NOT NULL,
    [building_address]       VARCHAR (255) NOT NULL,
    [building_manager]       VARCHAR (50)  NOT NULL,
    [building_phone]         VARCHAR (80)  NOT NULL,
    [other_building_details] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([building_id] ASC)
);
CREATE TABLE [dbo].[Ref_Apartment_Type] (
    [apt_type_code]        CHAR (15)     NOT NULL,
    [apt_type_description] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([apt_type_code] ASC)
);
CREATE TABLE [dbo].[Apartments] (
    [apt_id]                  INT           IDENTITY (1, 1) NOT NULL,
    [building_id]             INT           NOT NULL,
    [apt_type_code]           CHAR (15)     NOT NULL,
    [apt_number]              CHAR (10)     NOT NULL,
    [bathroom_count]          INT           NOT NULL,
    [bedroom_count]           INT           NOT NULL,
    [room_count]              CHAR (5)      NOT NULL,
    [other_apartment_details] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([apt_id] ASC),
    CONSTRAINT [FK_Apartments_ToTable] FOREIGN KEY ([building_id]) REFERENCES [dbo].[Apartment_Buildings] ([building_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Apartments_ToTable_1] FOREIGN KEY ([apt_type_code]) REFERENCES [dbo].[Ref_Apartment_Type] ([apt_type_code])
);
CREATE TABLE [dbo].[Ref_Apartment_Facilities] (
    [facility_code]        CHAR (15)     NOT NULL,
    [facility_description] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([facility_code] ASC)
);
CREATE TABLE [dbo].[Apartment_Wise_Facilities] (
    [apartment_wise_facility_id] INT       IDENTITY (1, 1) NOT NULL,
    [apt_id]                     INT       NOT NULL,
    [facility_code]              CHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([apartment_wise_facility_id] ASC),
    CONSTRAINT [FK_Apartment_Wise_Facilities_ToTable] FOREIGN KEY ([apt_id]) REFERENCES [dbo].[Apartments] ([apt_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Apartment_Wise_Facilities_ToTable_1] FOREIGN KEY ([facility_code]) REFERENCES [dbo].[Ref_Apartment_Facilities] ([facility_code]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [dbo].[View_Unit_Status] (
    [status_id]      INT      IDENTITY (1, 1) NOT NULL,
    [apt_id]         INT      NOT NULL,
    [apt_booking_id] INT      NOT NULL,
    [status_date]    DATETIME NOT NULL,
    [available_yn]   BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([status_id] ASC)
);
CREATE TABLE [dbo].[Ref_Booking_Status] (
    [booking_status_code]        CHAR (15)     NOT NULL,
    [booking_status_description] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([booking_status_code] ASC)
);
CREATE TABLE [dbo].[Ref_Gender] (
    [gender_code]        CHAR (1)  NOT NULL,
    [gender_description] CHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([gender_code] ASC)
);
CREATE TABLE [dbo].[Guests] (
    [guest_id]            INT           IDENTITY (1, 1) NOT NULL,
    [guest_first_name]    VARCHAR (80)  NOT NULL,
    [guest_last_name]     VARCHAR (80)  NOT NULL,
    [date_of_birth]       DATETIME      NOT NULL,
    [gender_code]         CHAR (1)      NOT NULL,
    [other_guest_details] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([guest_id] ASC),
    CONSTRAINT [FK_Guests_ToTable] FOREIGN KEY ([gender_code]) REFERENCES [dbo].[Ref_Gender] ([gender_code]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [dbo].[Apartment_Booking] (
    [apt_booking_id]        INT           IDENTITY (1, 1) NOT NULL,
    [apt_id]                INT           NOT NULL,
    [guest_id]              INT           NOT NULL,
    [booking_status_code]   CHAR (15)     NOT NULL,
    [booking_start_date]    DATETIME      NOT NULL,
    [booking_end_date]      DATETIME      NOT NULL,
    [other_booking_details] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([apt_booking_id] ASC),
    CONSTRAINT [FK_Apartment_Booking_ToTable] FOREIGN KEY ([apt_id]) REFERENCES [dbo].[Apartments] ([apt_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Apartment_Booking_ToTable_1] FOREIGN KEY ([guest_id]) REFERENCES [dbo].[Guests] ([guest_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Apartment_Booking_ToTable_2] FOREIGN KEY ([booking_status_code]) REFERENCES [dbo].[Ref_Booking_Status] ([booking_status_code]) ON DELETE CASCADE ON UPDATE CASCADE
);
