using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class addYield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("54a1a3f4-2fd8-4665-9fa2-523deb365f41"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "OperationsHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CheckingAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Yield",
                table: "CheckingAccounts",
                type: "decimal(16,3)",
                precision: 16,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

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
                keyValue: new Guid("e579a8b0-a653-42fe-9bb3-8b20f82a8b38"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "OperationsHistory");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CheckingAccounts");

            migrationBuilder.DropColumn(
                name: "Yield",
                table: "CheckingAccounts");

            migrationBuilder.UpdateData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"),
                columns: new[] { "CreationDate", "LastMonetization" },
                values: new object[] { new DateTime(2020, 10, 31, 21, 15, 28, 705, DateTimeKind.Local).AddTicks(7897), new DateTime(2020, 10, 31, 21, 15, 28, 706, DateTimeKind.Local).AddTicks(6791) });

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
