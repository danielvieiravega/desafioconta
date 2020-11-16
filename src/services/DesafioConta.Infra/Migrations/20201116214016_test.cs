using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e579a8b0-a653-42fe-9bb3-8b20f82a8b38"));

            migrationBuilder.UpdateData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"),
                columns: new[] { "CreationDate", "LastMonetization" },
                values: new object[] { new DateTime(2020, 11, 1, 18, 40, 15, 962, DateTimeKind.Local).AddTicks(7333), new DateTime(2020, 11, 1, 18, 40, 15, 963, DateTimeKind.Local).AddTicks(6960) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Deleted", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("5af4f712-e4a4-4884-8a32-5ff4564a7321"), new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), new DateTime(2020, 11, 16, 18, 40, 15, 965, DateTimeKind.Local).AddTicks(5417), false, "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

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
                keyValue: new Guid("5af4f712-e4a4-4884-8a32-5ff4564a7321"));

            migrationBuilder.UpdateData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"),
                columns: new[] { "CreationDate", "LastMonetization" },
                values: new object[] { new DateTime(2020, 10, 31, 22, 36, 11, 666, DateTimeKind.Local).AddTicks(5885), new DateTime(2020, 10, 31, 22, 36, 11, 667, DateTimeKind.Local).AddTicks(3512) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Deleted", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("e579a8b0-a653-42fe-9bb3-8b20f82a8b38"), new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), new DateTime(2020, 11, 15, 22, 36, 11, 668, DateTimeKind.Local).AddTicks(9804), false, "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

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
