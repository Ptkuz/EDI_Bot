using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Infos_InfoId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "InfoId",
                table: "Images",
                newName: "InfoKey");

            migrationBuilder.RenameIndex(
                name: "IX_Images_InfoId",
                table: "Images",
                newName: "IX_Images_InfoKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Infos_InfoKey",
                table: "Images",
                column: "InfoKey",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Infos_InfoKey",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "InfoKey",
                table: "Images",
                newName: "InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_InfoKey",
                table: "Images",
                newName: "IX_Images_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Infos_InfoId",
                table: "Images",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
