using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seats4Me.DataAccess.Migrations
{
    public partial class CreateSeats4MeDb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketKey",
                table: "Tickets",
                newName: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "TicketKey");
        }
    }
}
