using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeedbackModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_User_UserID",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UserID",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Feedbacks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FeedbackID = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true),
                    Completionpercentage = table.Column<double>(type: "REAL", nullable: false),
                    HoursSpent = table.Column<double>(type: "REAL", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Tasktitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Feedbacks_FeedbackID",
                        column: x => x.FeedbackID,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackID");
                    table.ForeignKey(
                        name: "FK_Task_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserID",
                table: "Feedbacks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_FeedbackID",
                table: "Task",
                column: "FeedbackID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserID",
                table: "Task",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_User_UserID",
                table: "Feedbacks",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }
    }
}
