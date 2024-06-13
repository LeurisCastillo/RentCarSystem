using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationCard = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    CreditCardNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    CreditLimit = table.Column<double>(type: "REAL", nullable: false),
                    PersonType = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationCard = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    WorkSchedule = table.Column<int>(type: "INTEGER", nullable: false),
                    CommissionPercentage = table.Column<double>(type: "REAL", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    VehiculeType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ChasisNumber = table.Column<string>(type: "TEXT", maxLength: 17, nullable: true),
                    MotorNumber = table.Column<string>(type: "TEXT", maxLength: 17, nullable: true),
                    PlateNumber = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    VehiculeTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: true),
                    VehiculeModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    FuelTypesId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsRented = table.Column<bool>(type: "INTEGER", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicule_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicule_FuelTypes_FuelTypesId",
                        column: x => x.FuelTypesId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicule_VehiculeModel_VehiculeModelId",
                        column: x => x.VehiculeModelId,
                        principalTable: "VehiculeModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicule_VehiculeType_VehiculeTypeId",
                        column: x => x.VehiculeTypeId,
                        principalTable: "VehiculeType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiculeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    HasScratches = table.Column<bool>(type: "INTEGER", nullable: false),
                    AmountOfFuel = table.Column<int>(type: "INTEGER", nullable: false),
                    HasReplacementWheel = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasHydraulicJack = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasBrokenGlass = table.Column<bool>(type: "INTEGER", nullable: false),
                    WheelState1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    WheelState2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    WheelState3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    WheelState4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspection_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspection_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspection_Vehicule_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RentAndDevolution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    VehiculeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    RentDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DevolutionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    AmountPerDay = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfDays = table.Column<int>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentAndDevolution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentAndDevolution_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentAndDevolution_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentAndDevolution_Vehicule_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_ClientId",
                table: "Inspection",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_EmployeeId",
                table: "Inspection",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_VehiculeId",
                table: "Inspection",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentAndDevolution_ClientId",
                table: "RentAndDevolution",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RentAndDevolution_EmployeeId",
                table: "RentAndDevolution",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentAndDevolution_VehiculeId",
                table: "RentAndDevolution",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_BrandId",
                table: "Vehicule",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_FuelTypesId",
                table: "Vehicule",
                column: "FuelTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_VehiculeModelId",
                table: "Vehicule",
                column: "VehiculeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_VehiculeTypeId",
                table: "Vehicule",
                column: "VehiculeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "RentAndDevolution");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Vehicule");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "VehiculeModel");

            migrationBuilder.DropTable(
                name: "VehiculeType");
        }
    }
}
