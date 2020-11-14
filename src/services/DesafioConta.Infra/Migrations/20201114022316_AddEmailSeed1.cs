using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class AddEmailSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d3b9066e-c0d1-49fc-aafb-31bbb65aab12"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("29ebab6a-7857-4a55-967f-66651c269f86"));

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("de4c8b0a-e7bf-4217-9092-8b12d2bd94a8"), 1, 0m, new DateTime(2020, 11, 13, 23, 23, 16, 13, DateTimeKind.Local).AddTicks(2009), new DateTime(2020, 11, 13, 23, 23, 16, 14, DateTimeKind.Local).AddTicks(4439), 100 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("87b36ce0-98c6-482b-9f2e-133bca478939"), new Guid("de4c8b0a-e7bf-4217-9092-8b12d2bd94a8"), new DateTime(2020, 11, 13, 23, 23, 16, 17, DateTimeKind.Local).AddTicks(1826), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("87b36ce0-98c6-482b-9f2e-133bca478939"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("de4c8b0a-e7bf-4217-9092-8b12d2bd94a8"));

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("29ebab6a-7857-4a55-967f-66651c269f86"), 1, 0m, new DateTime(2020, 11, 13, 23, 19, 20, 911, DateTimeKind.Local).AddTicks(8805), new DateTime(2020, 11, 13, 23, 19, 20, 913, DateTimeKind.Local).AddTicks(1834), 100 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("d3b9066e-c0d1-49fc-aafb-31bbb65aab12"), new Guid("29ebab6a-7857-4a55-967f-66651c269f86"), new DateTime(2020, 11, 13, 23, 19, 20, 915, DateTimeKind.Local).AddTicks(4180), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });
        }
    }
}
