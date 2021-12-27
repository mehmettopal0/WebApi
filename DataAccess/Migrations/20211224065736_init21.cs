using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_CommentLikes_CommentLikeId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_CommentLikeId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "CommentLikeId",
                table: "CommentLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentLikeId",
                table: "CommentLikes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentLikeId",
                table: "CommentLikes",
                column: "CommentLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_CommentLikes_CommentLikeId",
                table: "CommentLikes",
                column: "CommentLikeId",
                principalTable: "CommentLikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
