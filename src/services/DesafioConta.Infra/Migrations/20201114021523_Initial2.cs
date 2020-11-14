﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConta.Infra.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CheckingAccounts",
                columns: new[] { "Id", "Agency", "Balance", "CreationDate", "LastMonetization", "Number" },
                values: new object[] { new Guid("87553712-63ee-4139-a9d6-89b7f2fd9a82"), 1, 0m, new DateTime(2020, 11, 13, 23, 15, 23, 270, DateTimeKind.Local).AddTicks(4177), new DateTime(2020, 11, 13, 23, 15, 23, 272, DateTimeKind.Local).AddTicks(8571), 100 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CheckingAccountId", "CreationDate", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Cpf", "FirstName", "LastName" },
                values: new object[] { new Guid("4d64d082-46ff-44e2-9826-49c1919d45d5"), new Guid("87553712-63ee-4139-a9d6-89b7f2fd9a82"), new DateTime(2020, 11, 13, 23, 15, 23, 277, DateTimeKind.Local).AddTicks(4809), "Money", "94064340", "Porto Alegre", "Casa", "RS", "Warren Street", "123", "34074230046", "Warren", "Buffet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4d64d082-46ff-44e2-9826-49c1919d45d5"));

            migrationBuilder.DeleteData(
                table: "CheckingAccounts",
                keyColumn: "Id",
                keyValue: new Guid("87553712-63ee-4139-a9d6-89b7f2fd9a82"));
        }
    }
}
