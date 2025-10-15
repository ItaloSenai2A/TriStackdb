using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriStackdb.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigAlertas",
                columns: table => new
                {
                    ConfigAlertaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura = table.Column<float>(type: "real", nullable: true),
                    Ar = table.Column<float>(type: "real", nullable: true),
                    Vento = table.Column<float>(type: "real", nullable: true),
                    Agua = table.Column<float>(type: "real", nullable: true),
                    Solo = table.Column<float>(type: "real", nullable: true),
                    Luz = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigAlertas", x => x.ConfigAlertaId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura = table.Column<float>(type: "real", nullable: true),
                    Ar = table.Column<float>(type: "real", nullable: true),
                    Agua = table.Column<float>(type: "real", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Vento = table.Column<float>(type: "real", nullable: true),
                    Luz = table.Column<float>(type: "real", nullable: true),
                    Solo = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoAlertas",
                columns: table => new
                {
                    TipoAlertaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlertas", x => x.TipoAlertaId);
                });

            migrationBuilder.CreateTable(
                name: "VisaoGeral",
                columns: table => new
                {
                    VisaoGeralId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTemperatura = table.Column<float>(type: "real", nullable: true),
                    MediaSolo = table.Column<float>(type: "real", nullable: true),
                    MediaAr = table.Column<float>(type: "real", nullable: true),
                    MediaLuz = table.Column<float>(type: "real", nullable: true),
                    MediaAgua = table.Column<float>(type: "real", nullable: true),
                    MediaVento = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaoGeral", x => x.VisaoGeralId);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentosClientes",
                columns: table => new
                {
                    EquipamentoClienteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentosClientes", x => x.EquipamentoClienteId);
                    table.ForeignKey(
                        name: "FK_EquipamentosClientes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipamentosClientes_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEquipamentos",
                columns: table => new
                {
                    HistoricoEquipamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura = table.Column<float>(type: "real", nullable: true),
                    Ar = table.Column<float>(type: "real", nullable: true),
                    Agua = table.Column<float>(type: "real", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Vento = table.Column<float>(type: "real", nullable: true),
                    Luz = table.Column<float>(type: "real", nullable: true),
                    Solo = table.Column<float>(type: "real", nullable: true),
                    DataLeitura = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEquipamentos", x => x.HistoricoEquipamentoId);
                    table.ForeignKey(
                        name: "FK_HistoricoEquipamentos_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                });

            migrationBuilder.CreateTable(
                name: "AlertasEquipamentos",
                columns: table => new
                {
                    AlertasEquipamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    TipoAlertaId = table.Column<long>(type: "bigint", nullable: true),
                    DataAlerta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertasEquipamentos", x => x.AlertasEquipamentoId);
                    table.ForeignKey(
                        name: "FK_AlertasEquipamentos_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                    table.ForeignKey(
                        name: "FK_AlertasEquipamentos_TipoAlertas_TipoAlertaId",
                        column: x => x.TipoAlertaId,
                        principalTable: "TipoAlertas",
                        principalColumn: "TipoAlertaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertasEquipamentos_EquipamentoId",
                table: "AlertasEquipamentos",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertasEquipamentos_TipoAlertaId",
                table: "AlertasEquipamentos",
                column: "TipoAlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentosClientes_EquipamentoId",
                table: "EquipamentosClientes",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentosClientes_UserId",
                table: "EquipamentosClientes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEquipamentos_EquipamentoId",
                table: "HistoricoEquipamentos",
                column: "EquipamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertasEquipamentos");

            migrationBuilder.DropTable(
                name: "ConfigAlertas");

            migrationBuilder.DropTable(
                name: "EquipamentosClientes");

            migrationBuilder.DropTable(
                name: "HistoricoEquipamentos");

            migrationBuilder.DropTable(
                name: "VisaoGeral");

            migrationBuilder.DropTable(
                name: "TipoAlertas");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
