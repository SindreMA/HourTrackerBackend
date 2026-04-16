using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HourTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddExtrasToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeerwerkSeconds",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DhzSeconds",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MeerwerkSeconds", table: "Projects");
            migrationBuilder.DropColumn(name: "DhzSeconds", table: "Projects");
        }
    }
}
