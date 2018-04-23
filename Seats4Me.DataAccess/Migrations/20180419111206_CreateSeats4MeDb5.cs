using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seats4Me.DataAccess.Migrations
{
    public partial class CreateSeats4MeDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Schedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: true),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketKey);
                    table.ForeignKey(
                        name: "FK_Tickets_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduleId",
                table: "Tickets",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Shows_ShowId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "Tickets");

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
    }
}
