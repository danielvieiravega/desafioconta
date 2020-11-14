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
                    Balance = table.Column<decimal>(type: "decimal", nullable: false),
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
                    Operation = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
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

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("63d72d4e-7067-4404-9aa4-684394d9a5cf"), 1, 0m, new DateTime(2020, 11, 13, 23, 59, 28, 687, DateTimeKind.Local).AddTicks(5110), new DateTime(2020, 11, 13, 23, 59, 28, 688, DateTimeKind.Local).AddTicks(6281), 100 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("a8fd86ad-8638-43e9-ac79-b9f9c08945b0"), new Guid("63d72d4e-7067-4404-9aa4-684394d9a5cf"), new DateTime(2020, 11, 13, 23, 59, 28, 690, DateTimeKind.Local).AddTicks(7689), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

            migrationBuilder.InsertData(
                table: "OperationsHistory",
                columns: new[] { "Id", "Amount", "CheckingAccountId", "CreationDate", "Operation" },
                values: new object[] { new Guid("2bcb9462-fa25-431d-8e48-b37887282f14"), 100m, new Guid("63d72d4e-7067-4404-9aa4-684394d9a5cf"), new DateTime(2020, 11, 6, 23, 59, 28, 689, DateTimeKind.Local).AddTicks(7424), 0 });

            migrationBuilder.InsertData(
                table: "OperationsHistory",
                columns: new[] { "Id", "Amount", "CheckingAccountId", "CreationDate", "Operation" },
                values: new object[] { new Guid("92465811-907f-48ba-a4ed-08eb086d1578"), 400m, new Guid("63d72d4e-7067-4404-9aa4-684394d9a5cf"), new DateTime(2020, 11, 8, 23, 59, 28, 689, DateTimeKind.Local).AddTicks(8477), 0 });

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
