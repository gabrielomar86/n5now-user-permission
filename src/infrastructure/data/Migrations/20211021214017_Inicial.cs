using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace infrastructure.data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPermissionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    FechaCreacionRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserPermissionEntity",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacionRegistro", "Nombre", "Valor" },
                values: new object[] { new Guid("44ba65f8-ec30-4092-8beb-b952bf0c30df"), true, "mockData1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mockData1", 123m });

            migrationBuilder.InsertData(
                table: "UserPermissionEntity",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacionRegistro", "Nombre", "Valor" },
                values: new object[] { new Guid("ad1100bb-ee24-4444-8289-dfe712891324"), true, "mockData2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mockData2", 456m });

            migrationBuilder.InsertData(
                table: "UserPermissionEntity",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacionRegistro", "Nombre", "Valor" },
                values: new object[] { new Guid("0a696949-c4f3-4397-b330-b978ee48801d"), true, "mockData3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mockData3", 678m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissionEntity");
        }
    }
}
