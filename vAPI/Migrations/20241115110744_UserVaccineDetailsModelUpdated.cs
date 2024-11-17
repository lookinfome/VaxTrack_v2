using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserVaccineDetailsModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "UserVaccineDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingId",
                table: "UserVaccineDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
