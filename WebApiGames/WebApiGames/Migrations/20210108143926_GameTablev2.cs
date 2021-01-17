using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGames.Migrations
{
    public partial class GameTablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberofDislikes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberofLikes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberofDislikes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberofLikes",
                table: "Games");
        }
    }
}
