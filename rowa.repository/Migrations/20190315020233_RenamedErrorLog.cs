﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rowa.repository.Migrations
{
    public partial class RenamedErrorLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogging");

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Message = table.Column<string>(nullable: false),
                    StackTrace = table.Column<string>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    IsInner = table.Column<short>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Server = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.CreateTable(
                name: "ErrorLogging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IsInner = table.Column<short>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Server = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogging", x => x.Id);
                });
        }
    }
}
