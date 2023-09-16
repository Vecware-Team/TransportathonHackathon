using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportathonHackathon.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "TransportRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportRequests_VehicleId",
                table: "TransportRequests",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRequests_Vehicles_VehicleId",
                table: "TransportRequests",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRequests_Vehicles_VehicleId",
                table: "TransportRequests");

            migrationBuilder.DropIndex(
                name: "IX_TransportRequests_VehicleId",
                table: "TransportRequests");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "TransportRequests");
        }
    }
}
