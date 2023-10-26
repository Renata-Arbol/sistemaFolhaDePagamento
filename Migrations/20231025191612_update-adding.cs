using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaFolhaDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class updateadding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NoCtps",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PIS",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RNE",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Funcionarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "NoCtps",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "PIS",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "RNE",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Funcionarios");
        }
    }
}
