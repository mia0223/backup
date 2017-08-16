using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class UpdateProjectColorsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText
            (
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Seed\UpdateProjectColors3.sql")
            ));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
