using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Infos_InfoKey",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_InfoKey",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "InfoKey",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "VideoId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Infos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AudioId",
                table: "Audios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ServerInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoId",
                table: "Videos",
                column: "VideoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infos_ImageId",
                table: "Infos",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audios_AudioId",
                table: "Audios",
                column: "AudioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_ServerInfo_AudioId",
                table: "Audios",
                column: "AudioId",
                principalTable: "ServerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_Images_ImageId",
                table: "Infos",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_ServerInfo_VideoId",
                table: "Videos",
                column: "VideoId",
                principalTable: "ServerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_ServerInfo_AudioId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Infos_Images_ImageId",
                table: "Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_ServerInfo_VideoId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "ServerInfo");

            migrationBuilder.DropIndex(
                name: "IX_Videos_VideoId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Infos_ImageId",
                table: "Infos");

            migrationBuilder.DropIndex(
                name: "IX_Audios_AudioId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "Audios");

            migrationBuilder.AddColumn<Guid>(
                name: "InfoKey",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_InfoKey",
                table: "Images",
                column: "InfoKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Infos_InfoKey",
                table: "Images",
                column: "InfoKey",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
