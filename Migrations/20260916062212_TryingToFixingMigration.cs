using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeMadeApp.Migrations
{
    /// <inheritdoc />
    public partial class TryingToFixingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sellers",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sellers",
                newName: "ID");
        }
    }
}
