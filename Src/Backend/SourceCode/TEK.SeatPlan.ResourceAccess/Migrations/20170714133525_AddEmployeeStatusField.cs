using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class AddEmployeeStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Seat_EmployeeId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserCreated = table.Column<string>(maxLength: 64, nullable: false),
                    UserModified = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_EmployeeId",
                table: "Seat",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StatusId",
                table: "Employee",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeStatus_StatusId",
                table: "Employee",
                column: "StatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeStatus_StatusId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropIndex(
                name: "IX_Seat_EmployeeId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Employee_StatusId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_EmployeeId",
                table: "Seat",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectId",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
