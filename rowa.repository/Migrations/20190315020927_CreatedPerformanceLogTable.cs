using Microsoft.EntityFrameworkCore.Migrations;

namespace rowa.repository.Migrations
{
    public partial class CreatedPerformanceLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerformanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ServerName = table.Column<string>(maxLength: 200, nullable: false),
                    Uri = table.Column<string>(maxLength: 500, nullable: false),
                    Controller = table.Column<string>(maxLength: 200, nullable: false),
                    Method = table.Column<string>(maxLength: 200, nullable: false),
                    ExecutionTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceLog");
        }
    }
}
