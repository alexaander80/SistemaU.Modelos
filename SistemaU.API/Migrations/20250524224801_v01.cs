using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaU.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Correo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Biografia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Ponentes_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Secciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EstadoDeInscripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteCodigo",
                        column: x => x.ParticipanteCodigo,
                        principalTable: "Participantes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaEmision = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    esValido = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Monto = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MetodoDePago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_InscripcionCodigo",
                table: "Certificados",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoCodigo",
                table: "Inscripciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteCodigo",
                table: "Inscripciones",
                column: "ParticipanteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionCodigo",
                table: "Pagos",
                column: "InscripcionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ponentes_EventoCodigo",
                table: "Ponentes",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Secciones_EventoCodigo",
                table: "Secciones",
                column: "EventoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Secciones");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
