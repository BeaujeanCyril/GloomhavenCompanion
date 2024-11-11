using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GloomhavenCompanion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCompaignScenarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_Games_GameId",
                table: "Scenarios");

            migrationBuilder.DropIndex(
                name: "IX_Scenarios_GameId",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Scenarios");

            migrationBuilder.CreateTable(
                name: "CampaignScenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ScenarioId = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GameState = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignScenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignScenarios_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignScenarios_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Scenarios",
                columns: new[] { "Id", "CampaignId", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, null, "img/Scenarios/gh-1.png", "Scenario 1" },
                    { 2, null, "img/Scenarios/gh-2.png", "Scenario 2" },
                    { 3, null, "img/Scenarios/gh-3.png", "Scenario 3" },
                    { 4, null, "img/Scenarios/gh-4.png", "Scenario 4" },
                    { 5, null, "img/Scenarios/gh-5.png", "Scenario 5" },
                    { 6, null, "img/Scenarios/gh-6.png", "Scenario 6" },
                    { 7, null, "img/Scenarios/gh-7.png", "Scenario 7" },
                    { 8, null, "img/Scenarios/gh-8.png", "Scenario 8" },
                    { 9, null, "img/Scenarios/gh-9.png", "Scenario 9" },
                    { 10, null, "img/Scenarios/gh-10.png", "Scenario 10" },
                    { 11, null, "img/Scenarios/gh-11-12.png", "Scenario 11" },
                    { 12, null, "img/Scenarios/gh-11-12.png", "Scenario 12" },
                    { 13, null, "img/Scenarios/gh-13.png", "Scenario 13" },
                    { 14, null, "img/Scenarios/gh-14.png", "Scenario 14" },
                    { 15, null, "img/Scenarios/gh-15.png", "Scenario 15" },
                    { 16, null, "img/Scenarios/gh-16.png", "Scenario 16" },
                    { 17, null, "img/Scenarios/gh-17.png", "Scenario 17" },
                    { 18, null, "img/Scenarios/gh-18.png", "Scenario 18" },
                    { 19, null, "img/Scenarios/gh-19.png", "Scenario 19" },
                    { 20, null, "img/Scenarios/gh-20.png", "Scenario 20" },
                    { 21, null, "img/Scenarios/gh-21.png", "Scenario 21" },
                    { 22, null, "img/Scenarios/gh-22.png", "Scenario 22" },
                    { 23, null, "img/Scenarios/gh-23.png", "Scenario 23" },
                    { 24, null, "img/Scenarios/gh-24.png", "Scenario 24" },
                    { 25, null, "img/Scenarios/gh-25.png", "Scenario 25" },
                    { 26, null, "img/Scenarios/gh-26.png", "Scenario 26" },
                    { 27, null, "img/Scenarios/gh-27.png", "Scenario 27" },
                    { 28, null, "img/Scenarios/gh-28.png", "Scenario 28" },
                    { 29, null, "img/Scenarios/gh-29.png", "Scenario 29" },
                    { 30, null, "img/Scenarios/gh-30.png", "Scenario 30" },
                    { 31, null, "img/Scenarios/gh-31.png", "Scenario 31" },
                    { 32, null, "img/Scenarios/gh-32.png", "Scenario 32" },
                    { 33, null, "img/Scenarios/gh-33.png", "Scenario 33" },
                    { 34, null, "img/Scenarios/gh-34.png", "Scenario 34" },
                    { 35, null, "img/Scenarios/gh-35-36.png", "Scenario 35" },
                    { 36, null, "img/Scenarios/gh-35-36.png", "Scenario 36" },
                    { 37, null, "img/Scenarios/gh-37.png", "Scenario 37" },
                    { 38, null, "img/Scenarios/gh-38.png", "Scenario 38" },
                    { 39, null, "img/Scenarios/gh-39.png", "Scenario 39" },
                    { 40, null, "img/Scenarios/gh-40.png", "Scenario 40" },
                    { 41, null, "img/Scenarios/gh-41.png", "Scenario 41" },
                    { 42, null, "img/Scenarios/gh-42.png", "Scenario 42" },
                    { 43, null, "img/Scenarios/gh-43.png", "Scenario 43" },
                    { 44, null, "img/Scenarios/gh-44.png", "Scenario 44" },
                    { 45, null, "img/Scenarios/gh-45.png", "Scenario 45" },
                    { 46, null, "img/Scenarios/gh-46.png", "Scenario 46" },
                    { 47, null, "img/Scenarios/gh-47.png", "Scenario 47" },
                    { 48, null, "img/Scenarios/gh-48.png", "Scenario 48" },
                    { 49, null, "img/Scenarios/gh-49.png", "Scenario 49" },
                    { 50, null, "img/Scenarios/gh-50.png", "Scenario 50" },
                    { 51, null, "img/Scenarios/gh-51.png", "Scenario 51" },
                    { 52, null, "img/Scenarios/gh-52.png", "Scenario 52" },
                    { 53, null, "img/Scenarios/gh-53.png", "Scenario 53" },
                    { 54, null, "img/Scenarios/gh-54.png", "Scenario 54" },
                    { 55, null, "img/Scenarios/gh-55.png", "Scenario 55" },
                    { 56, null, "img/Scenarios/gh-56.png", "Scenario 56" },
                    { 57, null, "img/Scenarios/gh-57.png", "Scenario 57" },
                    { 58, null, "img/Scenarios/gh-58.png", "Scenario 58" },
                    { 59, null, "img/Scenarios/gh-59.png", "Scenario 59" },
                    { 60, null, "img/Scenarios/gh-60.png", "Scenario 60" },
                    { 61, null, "img/Scenarios/gh-61.png", "Scenario 61" },
                    { 62, null, "img/Scenarios/gh-62.png", "Scenario 62" },
                    { 63, null, "img/Scenarios/gh-63.png", "Scenario 63" },
                    { 64, null, "img/Scenarios/gh-64.png", "Scenario 64" },
                    { 65, null, "img/Scenarios/gh-65.png", "Scenario 65" },
                    { 66, null, "img/Scenarios/gh-66.png", "Scenario 66" },
                    { 67, null, "img/Scenarios/gh-67.png", "Scenario 67" },
                    { 68, null, "img/Scenarios/gh-68.png", "Scenario 68" },
                    { 69, null, "img/Scenarios/gh-69.png", "Scenario 69" },
                    { 70, null, "img/Scenarios/gh-70.png", "Scenario 70" },
                    { 71, null, "img/Scenarios/gh-71.png", "Scenario 71" },
                    { 72, null, "img/Scenarios/gh-72.png", "Scenario 72" },
                    { 73, null, "img/Scenarios/gh-73.png", "Scenario 73" },
                    { 74, null, "img/Scenarios/gh-74.png", "Scenario 74" },
                    { 75, null, "img/Scenarios/gh-75.png", "Scenario 75" },
                    { 76, null, "img/Scenarios/gh-76.png", "Scenario 76" },
                    { 77, null, "img/Scenarios/gh-77.png", "Scenario 77" },
                    { 78, null, "img/Scenarios/gh-78.png", "Scenario 78" },
                    { 79, null, "img/Scenarios/gh-79.png", "Scenario 79" },
                    { 80, null, "img/Scenarios/gh-80.png", "Scenario 80" },
                    { 81, null, "img/Scenarios/gh-81.png", "Scenario 81" },
                    { 82, null, "img/Scenarios/gh-82.png", "Scenario 82" },
                    { 83, null, "img/Scenarios/gh-83.png", "Scenario 83" },
                    { 84, null, "img/Scenarios/gh-84.png", "Scenario 84" },
                    { 85, null, "img/Scenarios/gh-85.png", "Scenario 85" },
                    { 86, null, "img/Scenarios/gh-86.png", "Scenario 86" },
                    { 87, null, "img/Scenarios/gh-87.png", "Scenario 87" },
                    { 88, null, "img/Scenarios/gh-88.png", "Scenario 88" },
                    { 89, null, "img/Scenarios/gh-89.png", "Scenario 89" },
                    { 90, null, "img/Scenarios/gh-90.png", "Scenario 90" },
                    { 91, null, "img/Scenarios/gh-91.png", "Scenario 91" },
                    { 92, null, "img/Scenarios/gh-92.png", "Scenario 92" },
                    { 93, null, "img/Scenarios/gh-93.png", "Scenario 93" },
                    { 94, null, "img/Scenarios/gh-94.png", "Scenario 94" },
                    { 95, null, "img/Scenarios/gh-95.png", "Scenario 95" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenarios_CampaignId",
                table: "CampaignScenarios",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenarios_ScenarioId",
                table: "CampaignScenarios",
                column: "ScenarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignScenarios");

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Scenarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Scenarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_GameId",
                table: "Scenarios",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_Games_GameId",
                table: "Scenarios",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
