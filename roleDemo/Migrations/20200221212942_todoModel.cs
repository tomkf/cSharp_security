using Microsoft.EntityFrameworkCore.Migrations;

namespace roleDemo.Migrations
{
    public partial class todoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Description", "IsComplete" },
                values: new object[] { 1, "Finish work", false });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Description", "IsComplete" },
                values: new object[] { 2, "Go to gym", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
