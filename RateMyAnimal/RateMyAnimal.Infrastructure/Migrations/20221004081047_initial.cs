using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMyAnimal.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "animal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "animal_category",
                columns: table => new
                {
                    animal_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal_category", x => new { x.animal_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_animal_category_animal_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_animal_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description" },
                values: new object[] { 1, "cat" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description" },
                values: new object[] { 2, "dog" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description" },
                values: new object[] { 3, "cute" });

            migrationBuilder.CreateIndex(
                name: "IX_animal_category_category_id",
                table: "animal_category",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animal_category");

            migrationBuilder.DropTable(
                name: "animal");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
