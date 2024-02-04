using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBroker.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoURLUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Properties");
        }
    }
}
