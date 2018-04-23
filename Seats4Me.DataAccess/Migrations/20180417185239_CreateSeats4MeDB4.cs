using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seats4Me.DataAccess.Migrations
{
    public partial class CreateSeats4MeDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Schedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
