using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace infrastructure.data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeForename = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmployeeSurname = table.Column<string>(type: "varchar(100)", nullable: false),
                    PermissionTypeId = table.Column<int>(type: "int", nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionType_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "mockData1" });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "mockData2" });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "mockData3" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "EmployeeForename", "EmployeeSurname", "PermissionDate", "PermissionTypeId" },
                values: new object[] { 1, "mockData1", "mockData1", new DateTime(2022, 5, 30, 22, 55, 45, 185, DateTimeKind.Local).AddTicks(1981), 1 });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "EmployeeForename", "EmployeeSurname", "PermissionDate", "PermissionTypeId" },
                values: new object[] { 2, "mockData2", "mockData2", new DateTime(2022, 5, 30, 22, 55, 45, 187, DateTimeKind.Local).AddTicks(571), 2 });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "EmployeeForename", "EmployeeSurname", "PermissionDate", "PermissionTypeId" },
                values: new object[] { 3, "mockData3", "mockData3", new DateTime(2022, 5, 30, 22, 55, 45, 187, DateTimeKind.Local).AddTicks(590), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeId",
                table: "Permission",
                column: "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionType");
        }
    }
}
