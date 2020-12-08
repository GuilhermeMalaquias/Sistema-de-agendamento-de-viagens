using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeAgendamentoDeViagens.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assentos",
                columns: table => new
                {
                    Numero_ass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe_ass = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assentos", x => x.Numero_ass);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    PassageiroId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_pas = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    Data_nasc_pas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo_pas = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CPF_pas = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Passaporte_pas = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    UF_pas = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade_pas = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bairro_pas = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CEP_pas = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email_pas = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.PassageiroId);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    VooId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem_voo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destino_voo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao_voo = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Data_partida_voo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_chegada_voo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.VooId);
                });

            migrationBuilder.CreateTable(
                name: "AssentoVoos",
                columns: table => new
                {
                    Numero_ass = table.Column<long>(type: "bigint", nullable: false),
                    VooId = table.Column<long>(type: "bigint", nullable: false),
                    AssentosNumero_ass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssentoVoos", x => new { x.Numero_ass, x.VooId });
                    table.ForeignKey(
                        name: "FK_AssentoVoos_Assentos_AssentosNumero_ass",
                        column: x => x.AssentosNumero_ass,
                        principalTable: "Assentos",
                        principalColumn: "Numero_ass",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssentoVoos_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "VooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_res = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco_res = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PassageiroId = table.Column<long>(type: "bigint", nullable: true),
                    VooId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Passageiros_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Passageiros",
                        principalColumn: "PassageiroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "VooId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssentoVoos_AssentosNumero_ass",
                table: "AssentoVoos",
                column: "AssentosNumero_ass");

            migrationBuilder.CreateIndex(
                name: "IX_AssentoVoos_VooId",
                table: "AssentoVoos",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_CPF_pas",
                table: "Passageiros",
                column: "CPF_pas",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_Email_pas",
                table: "Passageiros",
                column: "Email_pas",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_Passaporte_pas",
                table: "Passageiros",
                column: "Passaporte_pas",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PassageiroId",
                table: "Reservas",
                column: "PassageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas",
                column: "VooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssentoVoos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Assentos");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Voos");
        }
    }
}
