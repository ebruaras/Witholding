using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Stopaj_Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFilePaths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    FileDate = table.Column<DateTime>(nullable: false),
                    SftpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilePaths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DealerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(9596), "Login" },
                    { 2, 1, new DateTime(2020, 7, 10, 13, 14, 33, 992, DateTimeKind.Local).AddTicks(542), "SendMail" },
                    { 3, 1, new DateTime(2020, 7, 10, 13, 14, 33, 992, DateTimeKind.Local).AddTicks(603), "SendSMS" },
                    { 4, 1, new DateTime(2020, 7, 10, 13, 14, 33, 992, DateTimeKind.Local).AddTicks(608), "DownloadPDF" },
                    { 5, 1, new DateTime(2020, 7, 10, 13, 14, 33, 992, DateTimeKind.Local).AddTicks(612), "ChangePhone" },
                    { 6, 1, new DateTime(2020, 7, 10, 13, 14, 33, 992, DateTimeKind.Local).AddTicks(616), "Error" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 7, 10, 13, 14, 33, 967, DateTimeKind.Local).AddTicks(7021), "Dealer" },
                    { 2, 2, new DateTime(2020, 7, 10, 13, 14, 33, 969, DateTimeKind.Local).AddTicks(6788), "CallCenterAdmin" },
                    { 3, 2, new DateTime(2020, 7, 10, 13, 14, 33, 969, DateTimeKind.Local).AddTicks(6858), "SporToto" },
                    { 4, 2, new DateTime(2020, 7, 10, 13, 14, 33, 969, DateTimeKind.Local).AddTicks(6863), "CallCenter" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreatedDate", "DealerId", "DealerName", "Email", "FullName", "IsActive", "Password", "Phone", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "test sk", "İstanbul", 1, new DateTime(2020, 7, 10, 13, 14, 33, 990, DateTimeKind.Local).AddTicks(5529), 11111, "iddaa bayisi", "test@gmail.com", "test1", true, "013456", "5552223333", 1, 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(3996) },
                    { 2, "test sk", "İstanbul", 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(6525), null, null, null, "Çağrı merkezi admin", true, "013456", "5558883333", 2, 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(6714) },
                    { 3, "test sk", "İstanbul", 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(6768), 3, "SporToto ekranı", "test@gmail.com", "SporToto", true, "013456", "5552223333", 3, 1, new DateTime(2020, 7, 10, 13, 14, 33, 991, DateTimeKind.Local).AddTicks(6827) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserFilePaths");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
