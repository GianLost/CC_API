using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CC_API.Migrations
{
    /// <inheritdoc />
    public partial class CC_Migration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_copy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CopyCost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_copy", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_printerType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RentalValue = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_printerType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_printer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImplementationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WithdrawallDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Patrimony = table.Column<int>(type: "int", nullable: false),
                    PrinterTypeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_printer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_printer_tbl_printerType_PrinterTypeId",
                        column: x => x.PrinterTypeId,
                        principalTable: "tbl_printerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_statement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Ppb = table.Column<int>(type: "int", nullable: false),
                    Cpb = table.Column<int>(type: "int", nullable: false),
                    Pb = table.Column<int>(type: "int", nullable: false),
                    Cpp = table.Column<double>(type: "double", nullable: false),
                    Pt = table.Column<double>(type: "double", nullable: false),
                    Gt = table.Column<double>(type: "double", nullable: false),
                    PrinterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_statement_tbl_printer_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "tbl_printer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_printer_PrinterTypeId",
                table: "tbl_printer",
                column: "PrinterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_statement_PrinterId",
                table: "tbl_statement",
                column: "PrinterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_copy");

            migrationBuilder.DropTable(
                name: "tbl_statement");

            migrationBuilder.DropTable(
                name: "tbl_printer");

            migrationBuilder.DropTable(
                name: "tbl_printerType");
        }
    }
}
