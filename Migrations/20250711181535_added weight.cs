using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HourTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class addedweight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "WeekData",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "DefaultWeight",
                table: "Mechanics",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "WeekData");

            migrationBuilder.DropColumn(
                name: "DefaultWeight",
                table: "Mechanics");
        }
    }
}
