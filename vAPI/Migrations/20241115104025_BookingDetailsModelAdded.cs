using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookingDetailsModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "TEXT", nullable: false),
                    Dose1Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    D1HospitalName = table.Column<string>(type: "TEXT", nullable: false),
                    D1SlotNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Dose2Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    D2HospitalName = table.Column<string>(type: "TEXT", nullable: false),
                    D2SlotNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UserVaccinationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");
        }
    }
}
