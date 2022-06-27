using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_App_Api.Migrations
{
    public partial class songdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Songs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Songs");
        }
    }
}
