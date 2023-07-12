﻿// <auto-generated />
using System;
using GolfLeaderboard.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GolfLeaderboard.API.Migrations
{
    [DbContext(typeof(GolfLeaderboardDbContext))]
    partial class GolfLeaderboardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GolfLeaderboard.API.Models.DomainModels.GolfCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("CourseRating")
                        .HasColumnType("real");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRating")
                        .HasColumnType("int");

                    b.Property<int>("Yardage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GolfCourses");
                });

            modelBuilder.Entity("GolfLeaderboard.API.Models.DomainModels.Golfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("HandicapIndex")
                        .HasColumnType("real");

                    b.Property<string>("HomeCourse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Golfers");
                });

            modelBuilder.Entity("GolfLeaderboard.API.Models.DomainModels.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GolferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GolferId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("GolfLeaderboard.API.Models.DomainModels.Score", b =>
                {
                    b.HasOne("GolfLeaderboard.API.Models.DomainModels.Golfer", null)
                        .WithMany("Scores")
                        .HasForeignKey("GolferId");
                });

            modelBuilder.Entity("GolfLeaderboard.API.Models.DomainModels.Golfer", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
