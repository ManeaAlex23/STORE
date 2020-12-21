using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGames.Migrations
{
    public partial class GameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeCategory",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Disponibility",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUnits",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeCategory",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Disponibility",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberOfUnits",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Games");
        }
    }
}
