using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaFolhaDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Departamentos_DepartamentoId",
                table: "Cargos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "TiposEmail");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Cargos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartamentoId",
                table: "Cargos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    auto_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: true),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.auto_id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "auto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    auto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<long>(type: "bigint", nullable: true),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.auto_id);
                    table.ForeignKey(
                        name: "FK_Telefones_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "auto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEmail", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_EmpresaId",
                table: "Departamentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Departamentos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "auto_id");
        }
    }
}
