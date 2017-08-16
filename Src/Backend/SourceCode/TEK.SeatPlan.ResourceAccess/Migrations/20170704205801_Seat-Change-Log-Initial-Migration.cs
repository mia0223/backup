using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TEK.SeatPlan.ResourceAccess.Migrations
{
    public partial class SeatChangeLogInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatChangeLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    SourceSeatId = table.Column<int>(nullable: true),
                    TargetSeatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatChangeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatChangeLog_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatChangeLog_Seat_SourceSeatId",
                        column: x => x.SourceSeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatChangeLog_Seat_TargetSeatId",
                        column: x => x.TargetSeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatChangeLog_EmployeeId",
                table: "SeatChangeLog",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatChangeLog_SourceSeatId",
                table: "SeatChangeLog",
                column: "SourceSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatChangeLog_TargetSeatId",
                table: "SeatChangeLog",
                column: "TargetSeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatChangeLog");
        }
    }
}
