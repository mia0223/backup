using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class RunAddSeatLocation205206207208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText
            (
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Seed\AddSeatLocation205-206-207-208.sql")
            ));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
