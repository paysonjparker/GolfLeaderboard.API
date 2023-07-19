using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfLeaderboard.API.Migrations
{
    /// <inheritdoc />
    public partial class leaderboardmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores");

            migrationBuilder.AlterColumn<Guid>(
                name: "GolferId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaderboardId",
                table: "Golfers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GolfCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaderboards_GolfCourses_GolfCourseId",
                        column: x => x.GolfCourseId,
                        principalTable: "GolfCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_LeaderboardId",
                table: "Golfers",
                column: "LeaderboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_GolfCourseId",
                table: "Leaderboards",
                column: "GolfCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Golfers_Leaderboards_LeaderboardId",
                table: "Golfers",
                column: "LeaderboardId",
                principalTable: "Leaderboards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores",
                column: "GolferId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Golfers_Leaderboards_LeaderboardId",
                table: "Golfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropIndex(
                name: "IX_Golfers_LeaderboardId",
                table: "Golfers");

            migrationBuilder.DropColumn(
                name: "LeaderboardId",
                table: "Golfers");

            migrationBuilder.AlterColumn<Guid>(
                name: "GolferId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores",
                column: "GolferId",
                principalTable: "Golfers",
                principalColumn: "Id");
        }
    }
}
