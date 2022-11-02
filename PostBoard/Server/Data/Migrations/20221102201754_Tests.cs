using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostBoard.Server.Data.Migrations
{
    public partial class Tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostEntityId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryEntityId",
                table: "Posts",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostEntityId",
                table: "Comments",
                column: "PostEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostEntityId",
                table: "Comments",
                column: "PostEntityId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryEntityId",
                table: "Posts",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostEntityId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostEntityId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostEntityId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
