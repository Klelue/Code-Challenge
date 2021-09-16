using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_Challenge.Migrations
{
    public partial class MigrationCodeChallange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Room_RoomNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_RoomNumber",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber1",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_RoomNumber1",
                table: "People",
                column: "RoomNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Room_RoomNumber1",
                table: "People",
                column: "RoomNumber1",
                principalTable: "Room",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Room_RoomNumber1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_RoomNumber1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "RoomNumber1",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_RoomNumber",
                table: "People",
                column: "RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Room_RoomNumber",
                table: "People",
                column: "RoomNumber",
                principalTable: "Room",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
