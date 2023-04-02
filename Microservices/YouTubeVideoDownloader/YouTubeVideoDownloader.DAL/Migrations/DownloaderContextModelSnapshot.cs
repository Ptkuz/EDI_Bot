﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouTubeVideoDownloader.DAL.Context;

#nullable disable

namespace YouTubeVideoDownloader.DAL.Migrations
{
    [DbContext(typeof(DownloaderContext))]
    partial class DownloaderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Audio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("Bitrate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Bitrate")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<string>("FormatAudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FormatAudio")
                        .HasColumnOrder(4);

                    b.Property<Guid>("ServerInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("YouTubeInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("YouTubeInfoId");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Extention")
                        .HasColumnOrder(5);

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("ImageBytes")
                        .HasColumnOrder(4);

                    b.Property<Guid>("YouTubeInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("YouTubeInfoId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.ServerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AudioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ref")
                        .HasColumnOrder(4);

                    b.Property<int>("Size")
                        .HasColumnType("int")
                        .HasColumnName("Size")
                        .HasColumnOrder(5);

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AudioId")
                        .IsUnique();

                    b.HasIndex("VideoId")
                        .IsUnique();

                    b.ToTable("ServerInfos");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("Bitrate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Bitrate")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<string>("FormatAudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FormatAudio")
                        .HasColumnOrder(7);

                    b.Property<string>("FormatVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FormatVideo")
                        .HasColumnOrder(4);

                    b.Property<string>("FrameRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FrameRate")
                        .HasColumnOrder(6);

                    b.Property<Guid>("InfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Resolution")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateDeleted")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified")
                        .HasColumnOrder(2);

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("Duration")
                        .HasColumnOrder(6);

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title")
                        .HasColumnOrder(4);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("YouTubeInfos");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Audio", b =>
                {
                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", "YouTubeInfo")
                        .WithMany("Audios")
                        .HasForeignKey("YouTubeInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YouTubeInfo");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Image", b =>
                {
                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", "YouTubeInfo")
                        .WithOne("Image")
                        .HasForeignKey("YouTubeVideoDownloader.DAL.Entities.Image", "YouTubeInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YouTubeInfo");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.ServerInfo", b =>
                {
                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.Audio", "Audio")
                        .WithOne("ServerInfo")
                        .HasForeignKey("YouTubeVideoDownloader.DAL.Entities.ServerInfo", "AudioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.Video", "Video")
                        .WithOne("ServerInfo")
                        .HasForeignKey("YouTubeVideoDownloader.DAL.Entities.ServerInfo", "VideoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Audio");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Video", b =>
                {
                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", "Info")
                        .WithMany("Videos")
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", b =>
                {
                    b.HasOne("YouTubeVideoDownloader.DAL.Entities.Channel", "Channel")
                        .WithMany("YouTubeInfos")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Audio", b =>
                {
                    b.Navigation("ServerInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Channel", b =>
                {
                    b.Navigation("YouTubeInfos");
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.Video", b =>
                {
                    b.Navigation("ServerInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("YouTubeVideoDownloader.DAL.Entities.YouTubeInfo", b =>
                {
                    b.Navigation("Audios");

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
