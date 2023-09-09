using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportathonHackathon.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carriers_CarrierEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverEmployeeId",
                table: "AspNetUsers");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
