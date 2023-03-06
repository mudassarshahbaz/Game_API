using Microsoft.EntityFrameworkCore.Migrations;

namespace Game_API.Migrations
{
    public partial class TablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    PkGameResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.PkGameResultId);
                });

            migrationBuilder.CreateTable(
                name: "GameSession",
                columns: table => new
                {
                    PkGameSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false),
                    StartTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    EndTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PositiveActions = table.Column<int>(type: "int", nullable: false),
                    NegativeActions = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSession", x => x.PkGameSessionId);
                    table.ForeignKey(
                        name: "FK_GameSession_GameResults_GameResultId",
                        column: x => x.GameResultId,
                        principalTable: "GameResults",
                        principalColumn: "PkGameResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_GameResultId",
                table: "GameSession",
                column: "GameResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSession");

            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}
