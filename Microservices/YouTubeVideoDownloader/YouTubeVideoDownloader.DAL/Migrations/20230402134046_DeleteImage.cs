using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Images_ImageId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Streams_StreamId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Streams_StreamId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Channels_ChannelId",
                table: "Streams");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Images_ImageId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streams_StreamId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ImageId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Audios_ImageId",
                table: "Audios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streams",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Audios");

            migrationBuilder.RenameTable(
                name: "Streams",
                newName: "Infos");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Videos",
                newName: "InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_StreamId",
                table: "Videos",
                newName: "IX_Videos_InfoId");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Images",
                newName: "InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_StreamId",
                table: "Images",
                newName: "IX_Images_InfoId");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Audios",
                newName: "InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Audios_StreamId",
                table: "Audios",
                newName: "IX_Audios_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Streams_ChannelId",
                table: "Infos",
                newName: "IX_Infos_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Infos",
                table: "Infos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Infos_InfoId",
                table: "Images",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_Channels_ChannelId",
                table: "Infos",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Infos_InfoId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Infos_InfoId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Infos_Channels_ChannelId",
                table: "Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Infos_InfoId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Infos",
                table: "Infos");

            migrationBuilder.RenameTable(
                name: "Infos",
                newName: "Streams");

            migrationBuilder.RenameColumn(
                name: "InfoId",
                table: "Videos",
                newName: "StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_InfoId",
                table: "Videos",
                newName: "IX_Videos_StreamId");

            migrationBuilder.RenameColumn(
                name: "InfoId",
                table: "Images",
                newName: "StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_InfoId",
                table: "Images",
                newName: "IX_Images_StreamId");

            migrationBuilder.RenameColumn(
                name: "InfoId",
                table: "Audios",
                newName: "StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Audios_InfoId",
                table: "Audios",
                newName: "IX_Audios_StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Infos_ChannelId",
                table: "Streams",
                newName: "IX_Streams_ChannelId");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Audios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streams",
                table: "Streams",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ImageId",
                table: "Videos",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_ImageId",
                table: "Audios",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Images_ImageId",
                table: "Audios",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Streams_StreamId",
                table: "Audios",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Streams_StreamId",
                table: "Images",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Channels_ChannelId",
                table: "Streams",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Images_ImageId",
                table: "Videos",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streams_StreamId",
                table: "Videos",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
