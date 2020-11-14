using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckingAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agency = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    LastMonetization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(20)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    CheckingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CheckingAccounts_CheckingAccountId",
                        column: x => x.CheckingAccountId,
                        principalTable: "CheckingAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperationsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                        column: x => x.CheckingAccountId,
                        principalTable: "CheckingAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CheckingAccountId",
                table: "Customers",
                column: "CheckingAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationsHistory_CheckingAccountId",
                table: "OperationsHistory",
                column: "CheckingAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationsHistory");

            migrationBuilder.DropTable(
                name: "CheckingAccounts");
        }
    }
}
