﻿// <auto-generated />
using System;
using CuentasPorCobrar.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CuentasporcobrardbContext))]
    partial class CuentasporcobrardbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CuentasPorCobrar.Shared.AccountingEntry", b =>
                {
                    b.Property<int>("AccountingEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountingEntryId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("AccountEntryAmount")
                        .HasColumnType("money");

                    b.Property<DateTime>("AccountEntryDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("MovementType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountingEntryId");

                    b.ToTable("AccountingEntries");
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int?>("AccountingEntryId")
                        .HasColumnType("integer");

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("money");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("CustomerId");

                    b.HasIndex("AccountingEntryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("LedgerAccount")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MovementType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Customer", b =>
                {
                    b.HasOne("CuentasPorCobrar.Shared.AccountingEntry", null)
                        .WithMany("Customers")
                        .HasForeignKey("AccountingEntryId");

                    b.HasOne("CuentasPorCobrar.Shared.Transaction", null)
                        .WithMany("Customers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Document", b =>
                {
                    b.HasOne("CuentasPorCobrar.Shared.Transaction", null)
                        .WithMany("Documents")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.AccountingEntry", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("CuentasPorCobrar.Shared.Transaction", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
