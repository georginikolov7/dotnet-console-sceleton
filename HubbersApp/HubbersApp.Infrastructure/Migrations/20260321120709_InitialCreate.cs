using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HubbersApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hubbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Hub Id"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Hub Member Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hubbers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64b84d3c-946c-46e7-a9df-9e3f3123c8cb"), "Hubber 2" },
                    { new Guid("cfa5267c-769b-4faa-8680-b49b6d1de959"), "Hubber 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hubbers");
        }
    }
}
