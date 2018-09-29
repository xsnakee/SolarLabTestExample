using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarLab.Domain.Migrations
{
    public partial class AddOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Adverts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvertId",
                table: "AdvertComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BoardId",
                table: "Adverts",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertComments_AdvertId",
                table: "AdvertComments",
                column: "AdvertId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Boards_BoardId",
                table: "Adverts",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertComments_Adverts_AdvertId",
                table: "AdvertComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Boards_BoardId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_BoardId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_AdvertComments_AdvertId",
                table: "AdvertComments");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "AdvertId",
                table: "AdvertComments");
        }
    }
}
