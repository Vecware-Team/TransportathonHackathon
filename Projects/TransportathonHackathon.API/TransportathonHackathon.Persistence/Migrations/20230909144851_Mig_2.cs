using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportathonHackathon.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_AspNetUsers_AppUserId",
                table: "Carriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_AppUserId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsOnTransitNow",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsOnTransitNow",
                table: "Carriers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Drivers",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Carriers",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrierEmployeeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DriverEmployeeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOnTransitNow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarrierEmployeeId",
                table: "AspNetUsers",
                column: "CarrierEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DriverEmployeeId",
                table: "AspNetUsers",
                column: "DriverEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carriers_CarrierEmployeeId",
                table: "AspNetUsers",
                column: "CarrierEmployeeId",
                principalTable: "Carriers",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverEmployeeId",
                table: "AspNetUsers",
                column: "DriverEmployeeId",
                principalTable: "Drivers",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_Employees_EmployeeId",
                table: "Carriers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Employees_EmployeeId",
                table: "Drivers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carriers_CarrierEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_Employees_EmployeeId",
                table: "Carriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Employees_EmployeeId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarrierEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DriverEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarrierEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Drivers",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Carriers",
                newName: "AppUserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnTransitNow",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnTransitNow",
                table: "Carriers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_AspNetUsers_AppUserId",
                table: "Carriers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_AppUserId",
                table: "Drivers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
