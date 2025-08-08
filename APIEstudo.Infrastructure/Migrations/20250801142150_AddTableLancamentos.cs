using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEstudo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableLancamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lancamentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    usuario_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    banco_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    categoria_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    data_lancamento = table.Column<DateTime>(type: "date", nullable: false),
                    tipo = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    criado_em = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_lancamentos_bancos_banco_id",
                        column: x => x.banco_id,
                        principalTable: "bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamentos_categorias_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamentos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentos_banco_id",
                table: "lancamentos",
                column: "banco_id");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentos_categoria_id",
                table: "lancamentos",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentos_usuario_id",
                table: "lancamentos",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lancamentos");
        }
    }
}
