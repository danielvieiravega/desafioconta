using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class AdjustBalancePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsHistory_CheckingAccounts_CheckingAccountId",
                table: "OperationsHistory");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b17554a5-1434-49df-8e8a-157b8ee96a5b"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2414f7af-a310-479a-b82f-3d3c1e4741d4"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "CheckingAccounts",
                type: "decimal(16,3)",
                precision: 16,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), 1, 0m, new DateTime(2020, 10, 31, 11, 26, 4, 573, DateTimeKind.Local).AddTicks(1460), new DateTime(2020, 10, 31, 11, 26, 4, 573, DateTimeKind.Local).AddTicks(9884), 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("1c72588b-0849-4389-b97a-4d0e183617f5"), new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"), new DateTime(2020, 11, 15, 11, 26, 4, 576, DateTimeKind.Local).AddTicks(1211), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

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
                keyValue: new Guid("1c72588b-0849-4389-b97a-4d0e183617f5"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0ecf33e-4ffc-49f5-848c-b17e8377573e"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "CheckingAccounts",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,3)",
                oldPrecision: 16,
                oldScale: 3);

            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("2414f7af-a310-479a-b82f-3d3c1e4741d4"), 1, 0m, new DateTime(2020, 10, 30, 21, 41, 29, 846, DateTimeKind.Local).AddTicks(9819), new DateTime(2020, 10, 30, 21, 41, 29, 848, DateTimeKind.Local).AddTicks(238), 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("b17554a5-1434-49df-8e8a-157b8ee96a5b"), new Guid("2414f7af-a310-479a-b82f-3d3c1e4741d4"), new DateTime(2020, 11, 14, 21, 41, 29, 849, DateTimeKind.Local).AddTicks(7406), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "warren@buffet.com", "Warren", "Buffet" });

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
