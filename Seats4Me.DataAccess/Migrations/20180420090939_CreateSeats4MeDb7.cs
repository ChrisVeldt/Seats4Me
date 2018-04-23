using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seats4Me.DataAccess.Migrations
{
    public partial class CreateSeats4MeDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
