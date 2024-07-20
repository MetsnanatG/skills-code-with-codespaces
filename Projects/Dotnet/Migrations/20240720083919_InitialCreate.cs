using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICCID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMSI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Model", "Name" },
                values: new object[,]
                {
                    { 1, "M001", "D001" },
                    { 2, "M002", "D002" },
                    { 3, "M003", "D003" },
                    { 4, "M004", "D004" },
                    { 5, "M005", "D005" },
                    { 6, "M006", "D006" },
                    { 7, "M007", "D007" },
                    { 8, "M008", "D008" },
                    { 9, "M009", "D009" },
                    { 10, "M0010", "D0010" }
                });

            migrationBuilder.InsertData(
                table: "EVouchers",
                columns: new[] { "Id", "Code", "ExpiryDate" },
                values: new object[,]
                {
                    { 1, "10001", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1183) },
                    { 2, "10002", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1257) },
                    { 3, "10003", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1282) },
                    { 4, "10004", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1304) },
                    { 5, "10005", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1324) },
                    { 6, "10006", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1347) },
                    { 7, "10007", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1368) },
                    { 8, "10008", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1387) },
                    { 9, "10009", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1468) },
                    { 10, "100010", new DateTime(2024, 8, 19, 8, 39, 19, 18, DateTimeKind.Local).AddTicks(1491) }
                });

            migrationBuilder.InsertData(
                table: "SimCards",
                columns: new[] { "Id", "ICCID", "IMSI" },
                values: new object[,]
                {
                    { 1, "ICCID001", "IMSI001" },
                    { 2, "ICCID002", "IMSI002" },
                    { 3, "ICCID003", "IMSI003" },
                    { 4, "ICCID004", "IMSI004" },
                    { 5, "ICCID005", "IMSI005" },
                    { 6, "ICCID006", "IMSI006" },
                    { 7, "ICCID007", "IMSI007" },
                    { 8, "ICCID008", "IMSI008" },
                    { 9, "ICCID009", "IMSI009" },
                    { 10, "ICCID0010", "IMSI0010" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "EVouchers");

            migrationBuilder.DropTable(
                name: "SimCards");
        }
    }
}
