using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPersonas.Migrations
{
    public partial class MigracionAportes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    AporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    MontoTotal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.AporteId);
                });

            migrationBuilder.CreateTable(
                name: "tipoAportes",
                columns: table => new
                {
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    MontoDeseado = table.Column<double>(type: "REAL", nullable: false),
                    MontoLogrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoAportes", x => x.TipoAporteId);
                });

            migrationBuilder.CreateTable(
                name: "AportesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AporteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AportesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AportesDetalle_Aportes_AporteId",
                        column: x => x.AporteId,
                        principalTable: "Aportes",
                        principalColumn: "AporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 1, "Asilo De Ancianos", 3000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 2, "Fundacion de Cancer ", 5000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 3, "Orfanato ", 3000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 4, "Ciencia ", 2000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 5, "Educacion ", 1000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 6, "Cementerio ", 1000000000.0, 0.0 });

            migrationBuilder.InsertData(
                table: "tipoAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "MontoDeseado", "MontoLogrado" },
                values: new object[] { 7, "Zoologico", 1000000000.0, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalle_AporteId",
                table: "AportesDetalle",
                column: "AporteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AportesDetalle");

            migrationBuilder.DropTable(
                name: "tipoAportes");

            migrationBuilder.DropTable(
                name: "Aportes");
        }
    }
}
