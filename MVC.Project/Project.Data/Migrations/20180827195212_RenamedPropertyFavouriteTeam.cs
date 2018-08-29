using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Data.Migrations
{
    public partial class RenamedPropertyFavouriteTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_FavouriteTeamsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteTeamsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavouriteTeamsId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteTeamId",
                table: "AspNetUsers",
                column: "FavouriteTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_FavouriteTeamId",
                table: "AspNetUsers",
                column: "FavouriteTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_FavouriteTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteTeamId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteTeamsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteTeamsId",
                table: "AspNetUsers",
                column: "FavouriteTeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_FavouriteTeamsId",
                table: "AspNetUsers",
                column: "FavouriteTeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
