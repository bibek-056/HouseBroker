using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBroker.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpadtePropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BrokerContact",
                table: "Properties",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrokerContact",
                table: "Properties");
        }
    }
}
