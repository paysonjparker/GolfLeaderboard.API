using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfLeaderboard.API.Migrations
{
    /// <inheritdoc />
    public partial class addmembes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GolfCourseId",
                table: "Golfers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_GolfCourseId",
                table: "Golfers",
                column: "GolfCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Golfers_GolfCourses_GolfCourseId",
                table: "Golfers",
                column: "GolfCourseId",
                principalTable: "GolfCourses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Golfers_GolfCourses_GolfCourseId",
                table: "Golfers");

            migrationBuilder.DropIndex(
                name: "IX_Golfers_GolfCourseId",
                table: "Golfers");

            migrationBuilder.DropColumn(
                name: "GolfCourseId",
                table: "Golfers");
        }
    }
}
