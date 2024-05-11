using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Migrations
{
    /// <inheritdoc />
    public partial class ManufaturingYearToIntSeverityRangeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturingDate",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturingYear",
                table: "Works",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturingYear",
                table: "Works");

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufacturingDate",
                table: "Works",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
