using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class initModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartToTrain",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "amountTrainingPerDay",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastTrainingDate",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amountTrainingPerDay",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "lastTrainingDate",
                table: "Heroes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartToTrain",
                table: "Heroes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
