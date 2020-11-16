﻿// <auto-generated />
using System;
using DesafioConta.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioConta.Infra.Migrations
{
    [DbContext(typeof(CheckingAccountsContext))]
    [Migration("20201116001122_AdjustPrecisionHistory")]
    partial class AdjustPrecisionHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DesafioConta.Domain.Accounts.CheckingAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Agency")
                        .HasColumnType("int")
                        .HasColumnName("Agency");

                    b.Property<decimal>("Balance")
                        .HasPrecision(16, 3)
                        .HasColumnType("decimal(16,3)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastMonetization")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.ToTable("CheckingAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("387a49fc-73fc-4554-9db5-e37b3144d8e6"),
                            Agency = 1,
                            Balance = 0m,
                            CreationDate = new DateTime(2020, 10, 31, 21, 11, 21, 500, DateTimeKind.Local).AddTicks(7819),
                            LastMonetization = new DateTime(2020, 10, 31, 21, 11, 21, 501, DateTimeKind.Local).AddTicks(6512),
                            Number = 1
                        });
                });

            modelBuilder.Entity("DesafioConta.Domain.Accounts.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CheckingAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CheckingAccountId")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"),
                            CheckingAccountId = new Guid("387a49fc-73fc-4554-9db5-e37b3144d8e6"),
                            CreationDate = new DateTime(2020, 11, 15, 21, 11, 21, 503, DateTimeKind.Local).AddTicks(8759)
                        });
                });

            modelBuilder.Entity("DesafioConta.Domain.Accounts.CheckingAccount", b =>
                {
                    b.OwnsMany("DesafioConta.Domain.Accounts.OperationsHistory", "OperationsHistory", b1 =>
                        {
                            b1.Property<Guid>("CheckingAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(16, 3)
                                .HasColumnType("decimal(16,3)");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Operation")
                                .HasColumnType("int");

                            b1.HasKey("CheckingAccountId", "Id");

                            b1.ToTable("OperationsHistory");

                            b1.WithOwner("CheckingAccount")
                                .HasForeignKey("CheckingAccountId");

                            b1.Navigation("CheckingAccount");
                        });

                    b.Navigation("OperationsHistory");
                });

            modelBuilder.Entity("DesafioConta.Domain.Accounts.Customer", b =>
                {
                    b.HasOne("DesafioConta.Domain.Accounts.CheckingAccount", "CheckingAccount")
                        .WithOne("Customer")
                        .HasForeignKey("DesafioConta.Domain.Accounts.Customer", "CheckingAccountId")
                        .IsRequired();

                    b.OwnsOne("DesafioConta.Domain.Accounts.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .HasColumnType("varchar(250)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Estado")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Numero");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasData(
                                new
                                {
                                    CustomerId = new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"),
                                    Bairro = "Money",
                                    Cep = "94064340",
                                    Cidade = "Porto Alegre",
                                    Complemento = "Casa",
                                    Estado = "RS",
                                    Logradouro = "Warren Street",
                                    Numero = "123"
                                });
                        });

                    b.OwnsOne("DesafioConta.Domain.Accounts.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasData(
                                new
                                {
                                    CustomerId = new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"),
                                    Number = "34074230046"
                                });
                        });

                    b.OwnsOne("DesafioConta.Domain.Accounts.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("varchar(254)")
                                .HasColumnName("Email");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasData(
                                new
                                {
                                    CustomerId = new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"),
                                    Address = "warren@buffet.com"
                                });
                        });

                    b.OwnsOne("DesafioConta.Domain.Accounts.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasData(
                                new
                                {
                                    CustomerId = new Guid("b395c55f-6c97-4f2e-862e-cb3240056616"),
                                    FirstName = "Warren",
                                    LastName = "Buffet"
                                });
                        });

                    b.Navigation("Address");

                    b.Navigation("CheckingAccount");

                    b.Navigation("Cpf");

                    b.Navigation("Email");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("DesafioConta.Domain.Accounts.CheckingAccount", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}