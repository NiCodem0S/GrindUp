using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrindUp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrequencyTypes",
                columns: table => new
                {
                    FrequencyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyTypes", x => x.FrequencyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes)",
                columns: table => new
                {
                    MeasurementTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes)", x => x.MeasurementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    ObjectiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isArchived = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.ObjectiveId);
                    table.ForeignKey(
                        name: "FK_Objectives_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveSettings",
                columns: table => new
                {
                    ObjectiveSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    MeasurementTypeId = table.Column<int>(type: "int", nullable: false),
                    FrequencyTypeId = table.Column<int>(type: "int", nullable: false),
                    TargetAmount = table.Column<int>(type: "int", nullable: false),
                    CustomPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationValue = table.Column<int>(type: "int", nullable: false),
                    DurationUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveSettings", x => x.ObjectiveSettingsId);
                    table.ForeignKey(
                        name: "FK_ObjectiveSettings_MeasurementTypes)_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes)",
                        principalColumn: "MeasurementTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveSettings_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "ObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressLogs",
                columns: table => new
                {
                    ProgressLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressLogs", x => x.ProgressLogId);
                    table.ForeignKey(
                        name: "FK_ProgressLogs_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgressLogs_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "ObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_UserId",
                table: "Objectives",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveSettings_MeasurementTypeId",
                table: "ObjectiveSettings",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveSettings_ObjectiveId",
                table: "ObjectiveSettings",
                column: "ObjectiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgressLogs_ObjectiveId",
                table: "ProgressLogs",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressLogs_UserId",
                table: "ProgressLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrequencyTypes");

            migrationBuilder.DropTable(
                name: "ObjectiveSettings");

            migrationBuilder.DropTable(
                name: "ProgressLogs");

            migrationBuilder.DropTable(
                name: "MeasurementTypes)");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
