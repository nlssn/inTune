﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inTune.Data;

namespace inTune.Migrations
{
    [DbContext(typeof(inTuneContext))]
    [Migration("20210210170137_AddGenre")]
    partial class AddGenre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("inTune.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("inTune.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("inTune.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfTracks")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("inTune.Models.Record", b =>
                {
                    b.HasOne("inTune.Models.Artist", "Artist")
                        .WithMany("Discography")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("inTune.Models.Genre", null)
                        .WithMany("RecordsInGenre")
                        .HasForeignKey("GenreId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("inTune.Models.Artist", b =>
                {
                    b.Navigation("Discography");
                });

            modelBuilder.Entity("inTune.Models.Genre", b =>
                {
                    b.Navigation("RecordsInGenre");
                });
#pragma warning restore 612, 618
        }
    }
}
