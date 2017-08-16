using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class InsertEmployeeStatusRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("INSERT INTO EmployeeStatus (Name, UserCreated) VALUES ('In Office', 'seed')");
			migrationBuilder.Sql("INSERT INTO EmployeeStatus (Name, UserCreated) VALUES ('Working from Home', 'seed')");
			migrationBuilder.Sql("INSERT INTO EmployeeStatus (Name, UserCreated) VALUES ('On Leave', 'seed')");
		}

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}