using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseRentalManagementSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentBuildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BuildingFullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BuildingDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuildingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuildingManager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OtherBuildingDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentBuildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefApartmentFacilities",
                columns: table => new
                {
                    FacilityCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefApartmentFacilities", x => x.FacilityCode);
                });

            migrationBuilder.CreateTable(
                name: "RefApartmentTypes",
                columns: table => new
                {
                    AptTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptTypeDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefApartmentTypes", x => x.AptTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefBookingStatuses",
                columns: table => new
                {
                    BookingStatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatusDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefBookingStatuses", x => x.BookingStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "RefPaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeDetails = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tenantes",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantFirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TenantLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OtherTenantDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenantes", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    AptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    AptTypeCode = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    BedroomCount = table.Column<int>(type: "int", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    MonthlyRent = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    SecurityDepositAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    OtherApartmentDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.AptId);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "ApartmentBuildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_RefApartmentTypes_AptTypeCode",
                        column: x => x.AptTypeCode,
                        principalTable: "RefApartmentTypes",
                        principalColumn: "AptTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentBookings",
                columns: table => new
                {
                    AptBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    AptId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    BookingStatusCode = table.Column<int>(type: "int", nullable: false),
                    BookingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherBookingDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentBookings", x => x.AptBookingId);
                    table.ForeignKey(
                        name: "FK_ApartmentBookings_ApartmentBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "ApartmentBuildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentBookings_Apartments_AptId",
                        column: x => x.AptId,
                        principalTable: "Apartments",
                        principalColumn: "AptId");
                    table.ForeignKey(
                        name: "FK_ApartmentBookings_RefBookingStatuses_BookingStatusCode",
                        column: x => x.BookingStatusCode,
                        principalTable: "RefBookingStatuses",
                        principalColumn: "BookingStatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentBookings_Tenantes_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenantes",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ApartmentImages_Apartments_AptId",
                        column: x => x.AptId,
                        principalTable: "Apartments",
                        principalColumn: "AptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentWiseFacilities",
                columns: table => new
                {
                    ApartmentWiseFacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptId = table.Column<int>(type: "int", nullable: false),
                    FacilityCode = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentWiseFacilities", x => x.ApartmentWiseFacilityId);
                    table.ForeignKey(
                        name: "FK_ApartmentWiseFacilities_Apartments_AptId",
                        column: x => x.AptId,
                        principalTable: "Apartments",
                        principalColumn: "AptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentWiseFacilities_RefApartmentFacilities_FacilityCode",
                        column: x => x.FacilityCode,
                        principalTable: "RefApartmentFacilities",
                        principalColumn: "FacilityCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingPayments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymemtAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    AptBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_BookingPayments_ApartmentBookings_AptBookingId",
                        column: x => x.AptBookingId,
                        principalTable: "ApartmentBookings",
                        principalColumn: "AptBookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPayments_RefPaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "RefPaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityDeposites",
                columns: table => new
                {
                    DepositPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    AptBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityDeposites", x => x.DepositPaymentId);
                    table.ForeignKey(
                        name: "FK_SecurityDeposites_ApartmentBookings_AptBookingId",
                        column: x => x.AptBookingId,
                        principalTable: "ApartmentBookings",
                        principalColumn: "AptBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewUnitStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptId = table.Column<int>(type: "int", nullable: false),
                    AptBookingId = table.Column<int>(type: "int", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableYn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewUnitStatuses", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_ViewUnitStatuses_ApartmentBookings_AptBookingId",
                        column: x => x.AptBookingId,
                        principalTable: "ApartmentBookings",
                        principalColumn: "AptBookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewUnitStatuses_Apartments_AptId",
                        column: x => x.AptId,
                        principalTable: "Apartments",
                        principalColumn: "AptId");
                });

            migrationBuilder.InsertData(
                table: "RefBookingStatuses",
                columns: new[] { "BookingStatusCode", "BookingStatusDescription" },
                values: new object[] { 1, "Confirmed" });

            migrationBuilder.InsertData(
                table: "RefBookingStatuses",
                columns: new[] { "BookingStatusCode", "BookingStatusDescription" },
                values: new object[] { 2, "Provisional" });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentBookings_AptId",
                table: "ApartmentBookings",
                column: "AptId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentBookings_BookingStatusCode",
                table: "ApartmentBookings",
                column: "BookingStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentBookings_BuildingId",
                table: "ApartmentBookings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentBookings_TenantId",
                table: "ApartmentBookings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentImages_AptId",
                table: "ApartmentImages",
                column: "AptId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AptTypeCode",
                table: "Apartments",
                column: "AptTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BuildingId",
                table: "Apartments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentWiseFacilities_AptId",
                table: "ApartmentWiseFacilities",
                column: "AptId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentWiseFacilities_FacilityCode",
                table: "ApartmentWiseFacilities",
                column: "FacilityCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPayments_AptBookingId",
                table: "BookingPayments",
                column: "AptBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPayments_PaymentTypeId",
                table: "BookingPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityDeposites_AptBookingId",
                table: "SecurityDeposites",
                column: "AptBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewUnitStatuses_AptBookingId",
                table: "ViewUnitStatuses",
                column: "AptBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewUnitStatuses_AptId",
                table: "ViewUnitStatuses",
                column: "AptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentImages");

            migrationBuilder.DropTable(
                name: "ApartmentWiseFacilities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingPayments");

            migrationBuilder.DropTable(
                name: "SecurityDeposites");

            migrationBuilder.DropTable(
                name: "ViewUnitStatuses");

            migrationBuilder.DropTable(
                name: "RefApartmentFacilities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RefPaymentTypes");

            migrationBuilder.DropTable(
                name: "ApartmentBookings");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "RefBookingStatuses");

            migrationBuilder.DropTable(
                name: "Tenantes");

            migrationBuilder.DropTable(
                name: "ApartmentBuildings");

            migrationBuilder.DropTable(
                name: "RefApartmentTypes");
        }
    }
}
