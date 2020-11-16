using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class SetFixedDefaultAccountGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("387a49fc-73fc-4554-9db5-e37b3144d8e6"));

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), 1, 0m, new DateTime(2020, 10, 31, 21, 15, 28, 705, DateTimeKind.Local).AddTicks(7897), new DateTime(2020, 10, 31, 21, 15, 28, 706, DateTimeKind.Local).AddTicks(6791), 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("54a1a3f4-2fd8-4665-9fa2-523deb365f41"), new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), new DateTime(2020, 11, 15, 21, 15, 28, 709, DateTimeKind.Local).AddTicks(386), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

            migrationBuilder.AddForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory",
                column: "CheckingAccountId",
                principalTable: "CheckingAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("54a1a3f4-2fd8-4665-9fa2-523deb365f41"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"));

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("387a49fc-73fc-4554-9db5-e37b3144d8e6"), 1, 0m, new DateTime(2020, 10, 31, 21, 11, 21, 500, DateTimeKind.Local).AddTicks(7819), new DateTime(2020, 10, 31, 21, 11, 21, 501, DateTimeKind.Local).AddTicks(6512), 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"), new Guid("387a49fc-73fc-4554-9db5-e37b3144d8e6"), new DateTime(2020, 11, 15, 21, 11, 21, 503, DateTimeKind.Local).AddTicks(8759), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

            migrationBuilder.AddForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory",
                column: "CheckingAccountId",
                principalTable: "CheckingAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
