using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserVaccineDetailsModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVaccineDetails",
                columns: table => new
                {
                    UserVaccinationId = table.Column<string>(type: "TEXT", nullable: false),
                    UserVaccinationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    BookingId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVaccineDetails", x => x.UserVaccinationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVaccineDetails");
        }
    }
}
