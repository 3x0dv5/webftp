using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServ.Data.Persistence.Migrations
{
    public partial class ftpclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FtpClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(nullable: true),
                    InstanceId = table.Column<string>(nullable: true),
                    LastPing = table.Column<DateTime>(nullable: false),
                    FirstPing = table.Column<DateTime>(nullable: false),
                    ConnectionClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FtpClients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FtpClients");
        }
    }
}
