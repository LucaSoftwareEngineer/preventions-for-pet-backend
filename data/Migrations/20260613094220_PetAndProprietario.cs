using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class PetAndProprietario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proprietari",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pro_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proprietari", x => x.pro_id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    pet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pet_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pet_eta = table.Column<int>(type: "int", nullable: false),
                    pet_data_nascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pet_pro_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.pet_id);
                    table.ForeignKey(
                        name: "FK_pets_proprietari_pet_pro_id",
                        column: x => x.pet_pro_id,
                        principalTable: "proprietari",
                        principalColumn: "pro_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pets_pet_pro_id",
                table: "pets",
                column: "pet_pro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "proprietari");
        }
    }
}
