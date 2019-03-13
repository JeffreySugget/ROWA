using Microsoft.EntityFrameworkCore.Migrations;

namespace rowa.repository.Migrations
{
    public partial class CorrectTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageVist");

            migrationBuilder.CreateTable(
                name: "PageVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Url = table.Column<string>(nullable: false),
                    VisitCount = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageVisit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageVisit");

            migrationBuilder.CreateTable(
                name: "PageVist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IpAddress = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    VisitCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageVist", x => x.Id);
                });
        }
    }
}
