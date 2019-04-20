using Microsoft.EntityFrameworkCore.Migrations;

namespace rowa.repository.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into userrole 
                                    (role)
                                    VALUES
                                    ('Admin'),
                                    ('Standard')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM userrole");
        }
    }
}
