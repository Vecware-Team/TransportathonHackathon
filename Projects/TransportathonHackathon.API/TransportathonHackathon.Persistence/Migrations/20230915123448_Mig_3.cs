using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportathonHackathon.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOffice",
                table: "TransportRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "TransportTypeId",
                table: "TransportRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportRequests_TransportTypeId",
                table: "TransportRequests",
                column: "TransportTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRequests_TransportTypes_TransportTypeId",
                table: "TransportRequests",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRequests_TransportTypes_TransportTypeId",
                table: "TransportRequests");

            migrationBuilder.DropTable(
                name: "TransportTypes");

            migrationBuilder.DropIndex(
                name: "IX_TransportRequests_TransportTypeId",
                table: "TransportRequests");

            migrationBuilder.DropColumn(
                name: "TransportTypeId",
                table: "TransportRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsOffice",
                table: "TransportRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
