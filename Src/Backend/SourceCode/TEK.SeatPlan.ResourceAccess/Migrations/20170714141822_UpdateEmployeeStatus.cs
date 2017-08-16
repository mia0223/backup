using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class UpdateEmployeeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("UPDATE Employee SET StatusId = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}