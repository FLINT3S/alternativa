﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    [DbContext(typeof(AltContext))]
    [Migration("20220905193846_StaticIDs")]
    partial class StaticIDs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Database.Models.Account", b =>
                {
                    b.Property<decimal>("SocialClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("LastHwid")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("SocialClubId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.AccountEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("AccountEvents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AccountEvent");
                });

            modelBuilder.Entity("Database.Models.Bans.AbstractBan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("GivenBySocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Reason")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GivenBySocialClubId");

                    b.ToTable("Bans");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractBan");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("AccountSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Cash")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("InGameTime")
                        .HasColumnType("interval");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("LastPosition")
                        .HasColumnType("text");

                    b.Property<long?>("MainBankAccountId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<long>("StaticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("TimeToReborn")
                        .HasColumnType("interval");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountSocialClubId");

                    b.HasIndex("MainBankAccountId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Database.Models.CharacterAppearance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<List<float>>("FaceFeatures")
                        .HasColumnType("real[]");

                    b.Property<int>("FatherId")
                        .HasColumnType("integer");

                    b.Property<int>("MotherId")
                        .HasColumnType("integer");

                    b.Property<float>("Similarity")
                        .HasColumnType("real");

                    b.Property<float>("SkinSimilarity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterAppearance");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Bank", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Money")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("BankId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BankId1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("BankId1");

                    b.HasIndex("OwnerId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FromId")
                        .HasColumnType("bigint");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<long?>("ToId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("BankTransactions");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FromId")
                        .HasColumnType("bigint");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<long?>("ToId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("CryptoTransactions");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoWallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CryptoWallets");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasBaseType("Database.Models.AccountEvents.AccountEvent");

                    b.Property<decimal?>("AccountSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasIndex("AccountSocialClubId");

                    b.HasDiscriminator().HasValue("ConnectionEvent");
                });

            modelBuilder.Entity("Database.Models.Bans.PermanentBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<decimal>("AccountId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("PermanentBan");
                });

            modelBuilder.Entity("Database.Models.Bans.TemporaryBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<decimal?>("GivenToSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.HasIndex("GivenToSocialClubId");

                    b.HasDiscriminator().HasValue("TemporaryBan");
                });

            modelBuilder.Entity("Database.Models.Bans.AbstractBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenBy")
                        .WithMany()
                        .HasForeignKey("GivenBySocialClubId");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.HasOne("Database.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "MainBankAccount")
                        .WithMany()
                        .HasForeignKey("MainBankAccountId");
                });

            modelBuilder.Entity("Database.Models.CharacterAppearance", b =>
                {
                    b.HasOne("Database.Models.Character", "Character")
                        .WithOne("Appearance")
                        .HasForeignKey("Database.Models.CharacterAppearance", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankAccount", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.Bank", null)
                        .WithMany("Accounts")
                        .HasForeignKey("BankId");

                    b.HasOne("Database.Models.Economics.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId1");

                    b.HasOne("Database.Models.Character", "Owner")
                        .WithMany("BankAccounts")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "From")
                        .WithMany("Transactions")
                        .HasForeignKey("FromId");

                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.CryptoWallets.CryptoWallet", "From")
                        .WithMany("Transactions")
                        .HasForeignKey("FromId");

                    b.HasOne("Database.Models.Economics.CryptoWallets.CryptoWallet", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoWallet", b =>
                {
                    b.HasOne("Database.Models.Character", null)
                        .WithMany("CryptoWallets")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasOne("Database.Models.Account", null)
                        .WithMany("Connections")
                        .HasForeignKey("AccountSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Bans.PermanentBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenTo")
                        .WithOne("PermanentBan")
                        .HasForeignKey("Database.Models.Bans.PermanentBan", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Bans.TemporaryBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenTo")
                        .WithMany("TemporaryBans")
                        .HasForeignKey("GivenToSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
