using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vAPI.Migrations
{
    /// <inheritdoc />
    public partial class HospitalDetailsModelUpdatedWithAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalDetails",
                columns: table => new
                {
                    HospitalId = table.Column<string>(type: "TEXT", nullable: false),
                    HospitalName = table.Column<string>(type: "TEXT", nullable: false),
                    HospitalAvailableSlots = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDetails", x => x.HospitalId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalDetails");
        }
    }
}
