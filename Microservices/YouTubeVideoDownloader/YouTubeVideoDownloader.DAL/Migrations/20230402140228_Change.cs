using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id");
        }
    }
}
