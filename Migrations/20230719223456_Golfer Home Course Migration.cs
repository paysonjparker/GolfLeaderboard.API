using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfLeaderboard.API.Migrations
{
    /// <inheritdoc />
    public partial class GolferHomeCourseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeCourse",
                table: "Golfers");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeCourseId",
                table: "Golfers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_HomeCourseId",
                table: "Golfers",
                column: "HomeCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Golfers_GolfCourses_HomeCourseId",
                table: "Golfers",
                column: "HomeCourseId",
                principalTable: "GolfCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Golfers_GolfCourses_HomeCourseId",
                table: "Golfers");

            migrationBuilder.DropIndex(
                name: "IX_Golfers_HomeCourseId",
                table: "Golfers");

            migrationBuilder.DropColumn(
                name: "HomeCourseId",
                table: "Golfers");

            migrationBuilder.AddColumn<string>(
                name: "HomeCourse",
                table: "Golfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
