using Microsoft.EntityFrameworkCore.Migrations;

namespace rowa.repository.Migrations
{
    public partial class AddedIpAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "PerformanceLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "PerformanceLog");
        }
    }
}
