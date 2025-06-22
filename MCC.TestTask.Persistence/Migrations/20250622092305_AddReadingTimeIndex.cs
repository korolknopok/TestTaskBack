﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCC.TestTask.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddReadingTimeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_ReadingTime",
                table: "Posts",
                column: "ReadingTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_ReadingTime",
                table: "Posts");
        }
    }
}
