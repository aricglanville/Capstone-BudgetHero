﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitTests.DBContext;

#nullable disable

namespace UnitTests.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("ModelsLibrary.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BankAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("ModelsLibrary.Budget", b =>
                {
                    b.Property<int>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BudgetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BudgetType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BudgetId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("ModelsLibrary.BudgetCategory", b =>
                {
                    b.Property<int>("BudgetCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BudgetCategoryGroupID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CategoryAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BudgetCategoryID");

                    b.HasIndex("BudgetCategoryGroupID");

                    b.ToTable("BudgetCategories");
                });

            modelBuilder.Entity("ModelsLibrary.BudgetCategoryGroup", b =>
                {
                    b.Property<int>("BudgetCategoryGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryGroupDesc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BudgetCategoryGroupID");

                    b.ToTable("BudgetCategoryGroups");
                });

            modelBuilder.Entity("ModelsLibrary.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankAccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BudgetCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DepositAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ExpenseAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsHousehold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<bool?>("IsTransactionPaid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransactionMemo")
                        .HasColumnType("TEXT");

                    b.Property<string>("TransactionPayee")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionId");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("BudgetCategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ModelsLibrary.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("PercentageMod")
                        .HasColumnType("REAL");

                    b.Property<string>("UserImageLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("BudgetId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModelsLibrary.BankAccount", b =>
                {
                    b.HasOne("ModelsLibrary.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelsLibrary.BudgetCategory", b =>
                {
                    b.HasOne("ModelsLibrary.BudgetCategoryGroup", "BudgetCategoryGroup")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetCategoryGroup");
                });

            modelBuilder.Entity("ModelsLibrary.Transaction", b =>
                {
                    b.HasOne("ModelsLibrary.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsLibrary.BudgetCategory", "BudgetCategory")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("BudgetCategory");
                });

            modelBuilder.Entity("ModelsLibrary.User", b =>
                {
                    b.HasOne("ModelsLibrary.Budget", null)
                        .WithMany("Users")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("ModelsLibrary.Budget", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
