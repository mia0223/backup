﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class RunSeedSqlScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(File.ReadAllText
	        (
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Seed\InitialSeed.sql")
	        ));
		}

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}