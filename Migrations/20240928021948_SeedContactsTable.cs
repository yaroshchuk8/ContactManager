using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "DateOfBirth", "Married", "Name", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "John Doe", "555-1234", 50000m },
                    { 2, new DateTime(1985, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Jane Smith", "555-5678", 60000m },
                    { 3, new DateTime(1975, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mark Johnson", "555-9876", 75000m },
                    { 4, new DateTime(1992, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Emily Brown", "555-4321", 45000m },
                    { 5, new DateTime(1988, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Michael Wilson", "555-8765", 55000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
