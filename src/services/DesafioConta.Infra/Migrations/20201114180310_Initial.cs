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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal", nullable: false)
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
                values: new object[] { new Guid("911d8b02-5732-407b-ac42-201305bacfb3"), 1, 500m, new DateTime(2020, 10, 30, 15, 3, 9, 967, DateTimeKind.Local).AddTicks(4482), new DateTime(2020, 10, 30, 15, 3, 9, 968, DateTimeKind.Local).AddTicks(2095), 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("f1b0a055-7723-4113-ba52-f4e96028b68b"), new Guid("911d8b02-5732-407b-ac42-201305bacfb3"), new DateTime(2020, 11, 14, 15, 3, 9, 970, DateTimeKind.Local).AddTicks(539), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

            migrationBuilder.InsertData(
                table: "OperationsHistory",
                columns: new[] { "Id", "Amount", "CheckingAccountId", "CreationDate", "Operation" },
                values: new object[] { new Guid("cb4e2ad7-b88a-497c-b236-0df47d59fe53"), 100m, new Guid("911d8b02-5732-407b-ac42-201305bacfb3"), new DateTime(2020, 11, 7, 15, 3, 9, 969, DateTimeKind.Local).AddTicks(1950), 0 });

            migrationBuilder.InsertData(
                table: "OperationsHistory",
                columns: new[] { "Id", "Amount", "CheckingAccountId", "CreationDate", "Operation" },
                values: new object[] { new Guid("783db41b-b903-4dee-8ac7-5dd54eb62c24"), 400m, new Guid("911d8b02-5732-407b-ac42-201305bacfb3"), new DateTime(2020, 11, 9, 15, 3, 9, 969, DateTimeKind.Local).AddTicks(2814), 0 });

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
