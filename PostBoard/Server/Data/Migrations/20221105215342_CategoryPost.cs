using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostBoard.Server.Data.Migrations
{
    public partial class CategoryPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryEntityId",
                table: "Posts",
                column: "CategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryEntityId",
                table: "Posts",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
