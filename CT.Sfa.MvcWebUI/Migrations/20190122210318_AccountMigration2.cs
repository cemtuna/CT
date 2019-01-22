using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CT.Sfa.MvcWebUI.Migrations
{
    public partial class AccountMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TcIdentity",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFull",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                schema: "DSS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DealerId",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirmId",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TcIdentity",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserFull",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "DSS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                schema: "DSS",
                table: "AspNetUsers");
        }
    }
}
