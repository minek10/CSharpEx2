using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTrackingUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTrackingUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTrackingUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "CreationTrackingUserId", "DeleteDate", "DeleteTrackingUserId", "FirstName", "LastName", "UpdateDate", "UpdateTrackingUserId" },
                values: new object[,]
                {
                    { new Guid("3b13455d-38c9-40c6-a3da-1a229a68ed96"), new DateTime(2022, 12, 2, 16, 54, 20, 863, DateTimeKind.Local).AddTicks(8796), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Hazard", "Kylian", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7305d300-6db2-4998-942f-4becb924917c"), new DateTime(2022, 12, 2, 16, 54, 20, 863, DateTimeKind.Local).AddTicks(8796), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Hazard", "Thorgan", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("778f76b2-bbc2-41c0-8ddb-30d7c95eafc1"), new DateTime(2022, 12, 2, 16, 54, 20, 863, DateTimeKind.Local).AddTicks(8796), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Mpenza", "Emile", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d693862f-5b0c-45b2-a494-17e9d61832e7"), new DateTime(2022, 12, 2, 16, 54, 20, 863, DateTimeKind.Local).AddTicks(8796), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Mpenza", "Mbo", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f7fe7458-b047-400f-ae5a-d11c3363e76f"), new DateTime(2022, 12, 2, 16, 54, 20, 863, DateTimeKind.Local).AddTicks(8796), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Hazard", "Eden", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
