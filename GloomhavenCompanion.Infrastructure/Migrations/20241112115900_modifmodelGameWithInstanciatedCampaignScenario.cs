using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GloomhavenCompanion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifmodelGameWithInstanciatedCampaignScenario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_Campaigns_CampaignId",
                table: "Scenarios");

            migrationBuilder.DropIndex(
                name: "IX_Scenarios_CampaignId",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Scenarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Scenarios",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 38,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 39,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 40,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 41,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 42,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 43,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 44,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 45,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 46,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 47,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 48,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 49,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 50,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 51,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 52,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 53,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 54,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 55,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 56,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 57,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 58,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 59,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 60,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 61,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 62,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 63,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 64,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 65,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 66,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 67,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 68,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 69,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 70,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 71,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 72,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 73,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 74,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 75,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 76,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 77,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 78,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 79,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 80,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 81,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 82,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 83,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 84,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 85,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 86,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 87,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 88,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 89,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 90,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 91,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 92,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 93,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 94,
                column: "CampaignId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scenarios",
                keyColumn: "Id",
                keyValue: 95,
                column: "CampaignId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_CampaignId",
                table: "Scenarios",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_Campaigns_CampaignId",
                table: "Scenarios",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }
    }
}
