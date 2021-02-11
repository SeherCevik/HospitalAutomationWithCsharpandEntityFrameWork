using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWorkHastaneOto.Migrations
{
    public partial class Doktor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hastadetaylar_Hasta_HastaId",
                table: "hastadetaylar");

            migrationBuilder.DropIndex(
                name: "IX_hastadetaylar_HastaId",
                table: "hastadetaylar");

            migrationBuilder.AlterColumn<int>(
                name: "HastaId",
                table: "hastadetaylar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "doktorlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doktorlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DoktorHasta",
                columns: table => new
                {
                    doktorlarID = table.Column<int>(type: "int", nullable: false),
                    hastalarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorHasta", x => new { x.doktorlarID, x.hastalarID });
                    table.ForeignKey(
                        name: "FK_DoktorHasta_doktorlar_doktorlarID",
                        column: x => x.doktorlarID,
                        principalTable: "doktorlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorHasta_Hasta_hastalarID",
                        column: x => x.hastalarID,
                        principalTable: "Hasta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hastadetaylar_HastaId",
                table: "hastadetaylar",
                column: "HastaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoktorHasta_hastalarID",
                table: "DoktorHasta",
                column: "hastalarID");

            migrationBuilder.AddForeignKey(
                name: "FK_hastadetaylar_Hasta_HastaId",
                table: "hastadetaylar",
                column: "HastaId",
                principalTable: "Hasta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hastadetaylar_Hasta_HastaId",
                table: "hastadetaylar");

            migrationBuilder.DropTable(
                name: "DoktorHasta");

            migrationBuilder.DropTable(
                name: "doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_hastadetaylar_HastaId",
                table: "hastadetaylar");

            migrationBuilder.AlterColumn<int>(
                name: "HastaId",
                table: "hastadetaylar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_hastadetaylar_HastaId",
                table: "hastadetaylar",
                column: "HastaId",
                unique: true,
                filter: "[HastaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_hastadetaylar_Hasta_HastaId",
                table: "hastadetaylar",
                column: "HastaId",
                principalTable: "Hasta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
