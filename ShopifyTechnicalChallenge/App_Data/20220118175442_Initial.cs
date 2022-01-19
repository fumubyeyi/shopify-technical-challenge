﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopifyTechnicalChallenge.App_Data
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Description", "LastModified", "Name", "Price", "Quantity" },
                values: new object[] { 1, "Item 1", new DateTime(2022, 1, 18, 12, 54, 41, 922, DateTimeKind.Local).AddTicks(3310), "Item 1", 19.989999999999998, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Name",
                table: "Inventory",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
