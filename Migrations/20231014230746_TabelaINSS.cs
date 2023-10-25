using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaFolhaDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class TabelaINSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaINSS",
                columns: table => new
                {
                    auto_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aliquota = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FaixaInicial = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FaixaFinal = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaINSS", x => x.auto_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaINSS");
        }
    }
}
