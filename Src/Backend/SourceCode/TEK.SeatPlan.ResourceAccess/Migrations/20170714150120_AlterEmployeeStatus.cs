using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class AlterEmployeeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropIndex(name: "IX_Employee_StatusId", table: "Employee");

			migrationBuilder.AlterColumn<int>(name: "StatusId", table: "Employee", nullable: false);

			migrationBuilder.CreateIndex(name: "IX_Employee_StatusId", table: "Employee", column: "StatusId");
		}

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
