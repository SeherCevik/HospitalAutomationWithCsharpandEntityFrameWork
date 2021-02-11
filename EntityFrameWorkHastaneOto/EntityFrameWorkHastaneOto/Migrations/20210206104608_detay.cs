using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWorkHastaneOto.Migrations
{
    public partial class detay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Hasta");

            migrationBuilder.DropColumn(
                name: "Kilo",
                table: "Hasta");

            migrationBuilder.DropColumn(
                name: "Yas",
                table: "Hasta");

            migrationBuilder.CreateTable(
                name: "hastadetaylar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yas = table.Column<int>(type: "int", nullable: true),
                    Kilo = table.Column<int>(type: "int", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HastaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hastadetaylar", x => x.id);
                    table.ForeignKey(
                        name: "FK_hastadetaylar_Hasta_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hasta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hastadetaylar_HastaId",
                table: "hastadetaylar",
                column: "HastaId",
                unique: true,
                filter: "[HastaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hastadetaylar");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "Hasta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kilo",
                table: "Hasta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Yas",
                table: "Hasta",
                type: "int",
                nullable: true);
        }
    }
}
