using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelDetails",
                columns: table => new
                {
                    LabelID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelHeading = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NoteID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelDetails", x => x.LabelID);
                    table.ForeignKey(
                        name: "FK_LabelDetails_NoteDetails_NoteID",
                        column: x => x.NoteID,
                        principalTable: "NoteDetails",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabelDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelDetails_NoteID",
                table: "LabelDetails",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_LabelDetails_UserId",
                table: "LabelDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelDetails");
        }
    }
}
