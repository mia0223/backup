﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class UpdateProjectColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText
            (
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Seed\UpdateProjectColors.sql")
            ));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
