using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class AlterProjectAddTechnicalServiceManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicalServiceManager",
                table: "Project",
                maxLength: 55,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicalServiceManager",
                table: "Project");
        }
    }
}
