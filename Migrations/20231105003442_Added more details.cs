using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HourTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class Addedmoredetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Common_CommonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanics_Common_CommonId",
                table: "Mechanics");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Common_CommonId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Common",
                table: "Common");

            migrationBuilder.RenameTable(
                name: "Common",
                newName: "Commons");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commons",
                table: "Commons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Commons_CommonId",
                table: "Comments",
                column: "CommonId",
                principalTable: "Commons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanics_Commons_CommonId",
                table: "Mechanics",
                column: "CommonId",
                principalTable: "Commons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Commons_CommonId",
                table: "Projects",
                column: "CommonId",
                principalTable: "Commons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Commons_CommonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanics_Commons_CommonId",
                table: "Mechanics");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Commons_CommonId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commons",
                table: "Commons");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Commons",
                newName: "Common");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Common",
                table: "Common",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Common_CommonId",
                table: "Comments",
                column: "CommonId",
                principalTable: "Common",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanics_Common_CommonId",
                table: "Mechanics",
                column: "CommonId",
                principalTable: "Common",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Common_CommonId",
                table: "Projects",
                column: "CommonId",
                principalTable: "Common",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
