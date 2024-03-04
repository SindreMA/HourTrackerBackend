using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HourTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class addedlinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicProject");

            migrationBuilder.CreateTable(
                name: "ProjectMecanicLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    MechanicId = table.Column<int>(type: "integer", nullable: false),
                    WeekDataId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMecanicLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectMecanicLinks_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMecanicLinks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeekData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeekNumber = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    SecondsWorked = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WeekDataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekData_ProjectMecanicLinks_WeekDataId",
                        column: x => x.WeekDataId,
                        principalTable: "ProjectMecanicLinks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMecanicLinks_MechanicId",
                table: "ProjectMecanicLinks",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMecanicLinks_ProjectId",
                table: "ProjectMecanicLinks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekData_WeekDataId",
                table: "WeekData",
                column: "WeekDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekData");

            migrationBuilder.DropTable(
                name: "ProjectMecanicLinks");

            migrationBuilder.CreateTable(
                name: "MechanicProject",
                columns: table => new
                {
                    MechanicsId = table.Column<int>(type: "integer", nullable: false),
                    ProjectsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicProject", x => new { x.MechanicsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_MechanicProject_Mechanics_MechanicsId",
                        column: x => x.MechanicsId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicProject_ProjectsId",
                table: "MechanicProject",
                column: "ProjectsId");
        }
    }
}
