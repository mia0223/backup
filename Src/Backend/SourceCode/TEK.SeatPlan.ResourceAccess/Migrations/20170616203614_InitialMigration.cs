using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Cols = table.Column<int>(nullable: false, defaultValueSql: "30"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FloorLevel = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Rows = table.Column<int>(nullable: false, defaultValueSql: "50"),
                    UserCreated = table.Column<string>(maxLength: 64, nullable: false),
                    UserModified = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Location_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    BackgroundColor = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ForegroundColor = table.Column<string>(nullable: true),
                    Internal = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    UserCreated = table.Column<string>(maxLength: 64, nullable: false),
                    UserModified = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 55, nullable: false),
                    FirstName = table.Column<string>(maxLength: 55, nullable: false),
                    LastName = table.Column<string>(maxLength: 55, nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    UserCreated = table.Column<string>(maxLength: 64, nullable: false),
                    UserModified = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    Col = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Transit = table.Column<bool>(nullable: false, defaultValue: false),
                    UserCreated = table.Column<string>(maxLength: 64, nullable: false),
                    UserModified = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seat_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectId",
                table: "Employee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Name",
                table: "Location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_ParentId",
                table: "Location",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Name",
                table: "Project",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_EmployeeId",
                table: "Seat",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_LocationId_Number",
                table: "Seat",
                columns: new[] { "LocationId", "Number" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
