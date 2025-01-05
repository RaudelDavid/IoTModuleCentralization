using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoT_Module_Centralization.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoUnidad",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Modules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Modules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoUnidad",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Modules");
        }
    }
}
