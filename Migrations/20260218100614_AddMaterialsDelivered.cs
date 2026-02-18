using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HourTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialsDelivered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MaterialsDelivered",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialsDelivered",
                table: "Projects");
        }
    }
}
