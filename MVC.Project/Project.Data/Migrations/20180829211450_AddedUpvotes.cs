using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Data.Migrations
{
    public partial class AddedUpvotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDisliked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasLiked",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Articles",
                newName: "Upvotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Upvotes",
                table: "Articles",
                newName: "Likes");

            migrationBuilder.AddColumn<bool>(
                name: "HasDisliked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLiked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Articles",
                nullable: false,
                defaultValue: 0);
        }
    }
}
