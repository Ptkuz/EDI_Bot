using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Videos_VideoId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "VideoFormat",
                table: "Videos",
                newName: "Resolution");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Videos",
                newName: "FrameRate");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Videos",
                newName: "FormatVideo");

            migrationBuilder.RenameColumn(
                name: "FTPRef",
                table: "Videos",
                newName: "FormatAudio");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Videos",
                newName: "StreamId");

            migrationBuilder.RenameColumn(
                name: "AudioFormat",
                table: "Videos",
                newName: "Bitrate");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_ChannelId",
                table: "Videos",
                newName: "IX_Videos_StreamId");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Images",
                newName: "StreamId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_VideoId",
                table: "Images",
                newName: "IX_Images_StreamId");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bitrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormatAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audios_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audios_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ImageId",
                table: "Videos",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_ImageId",
                table: "Audios",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_StreamId",
                table: "Audios",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_ChannelId",
                table: "Streams",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Streams_StreamId",
                table: "Images",
                column: "StreamId",
                principalTable: "Streams",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Streams_StreamId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Images_ImageId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streams_StreamId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ImageId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Videos",
                newName: "ChannelId");

            migrationBuilder.RenameColumn(
                name: "Resolution",
                table: "Videos",
                newName: "VideoFormat");

            migrationBuilder.RenameColumn(
                name: "FrameRate",
                table: "Videos",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "FormatVideo",
                table: "Videos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FormatAudio",
                table: "Videos",
                newName: "FTPRef");

            migrationBuilder.RenameColumn(
                name: "Bitrate",
                table: "Videos",
                newName: "AudioFormat");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_StreamId",
                table: "Videos",
                newName: "IX_Videos_ChannelId");

            migrationBuilder.RenameColumn(
                name: "StreamId",
                table: "Images",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_StreamId",
                table: "Images",
                newName: "IX_Images_VideoId");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Videos_VideoId",
                table: "Images",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
