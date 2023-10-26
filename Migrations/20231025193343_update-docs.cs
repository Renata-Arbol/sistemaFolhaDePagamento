using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaFolhaDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class updatedocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NoCtps",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PIS",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RNE",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "NoCtps",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "PIS",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "RNE",
                table: "Documentos");

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
        }
    }
}
