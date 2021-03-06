using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_Challenge.Migrations
{
    public partial class MigrationCodeChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    LdapUser = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NameAddition = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    RoomNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.LdapUser);
                    table.ForeignKey(
                        name: "FK_People_Room_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_RoomNumber",
                table: "People",
                column: "RoomNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
