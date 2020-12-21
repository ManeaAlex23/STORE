using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGames.Migrations
{
    public partial class AuditInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModefiedOn",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModefiedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ModefiedOn",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModefiedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");
        }
    }
}
