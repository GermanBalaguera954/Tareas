﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class ArchivosAdjuntos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArchivoAdjuntoId",
                table: "Pasos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivoAdjuntos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tareaid = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArchivoAdjuntoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoAdjuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivoAdjuntos_ArchivoAdjuntos_ArchivoAdjuntoId",
                        column: x => x.ArchivoAdjuntoId,
                        principalTable: "ArchivoAdjuntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArchivoAdjuntos_Tareas_Tareaid",
                        column: x => x.Tareaid,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasos_ArchivoAdjuntoId",
                table: "Pasos",
                column: "ArchivoAdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoAdjuntos_ArchivoAdjuntoId",
                table: "ArchivoAdjuntos",
                column: "ArchivoAdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoAdjuntos_Tareaid",
                table: "ArchivoAdjuntos",
                column: "Tareaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pasos_ArchivoAdjuntos_ArchivoAdjuntoId",
                table: "Pasos",
                column: "ArchivoAdjuntoId",
                principalTable: "ArchivoAdjuntos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasos_ArchivoAdjuntos_ArchivoAdjuntoId",
                table: "Pasos");

            migrationBuilder.DropTable(
                name: "ArchivoAdjuntos");

            migrationBuilder.DropIndex(
                name: "IX_Pasos_ArchivoAdjuntoId",
                table: "Pasos");

            migrationBuilder.DropColumn(
                name: "ArchivoAdjuntoId",
                table: "Pasos");
        }
    }
}
