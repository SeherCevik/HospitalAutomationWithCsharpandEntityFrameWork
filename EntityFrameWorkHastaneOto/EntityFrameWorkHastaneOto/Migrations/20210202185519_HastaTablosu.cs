using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWorkHastaneOto.Migrations
{
    public partial class HastaTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hasta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: true),
                    TC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Kilo = table.Column<int>(type: "int", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hasta", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hasta");
        }
    }
}
