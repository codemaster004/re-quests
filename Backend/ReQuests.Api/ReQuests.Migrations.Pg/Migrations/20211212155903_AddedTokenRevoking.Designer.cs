﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReQuests.Data;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211212155903_AddedTokenRevoking")]
    partial class AddedTokenRevoking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReQuests.Domain.Models.QuestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AwardUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.HasKey("Id");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.RoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.TokenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.Property<bool>("Revoked")
                        .HasColumnType("boolean");

                    b.Property<string>("UserUuid")
                        .IsRequired()
                        .HasColumnType("character varying(24)");

                    b.Property<DateTimeOffset>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccessToken")
                        .IsUnique();

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.HasIndex("UserUuid");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReQuests.Domain.Relations.UserQuestRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Attempts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTimeOffset?>("DateCompleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateStarted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QuestId")
                        .HasColumnType("integer");

                    b.Property<string>("UserUuid")
                        .IsRequired()
                        .HasColumnType("character varying(24)");

                    b.Property<bool>("WasWinReceived")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("QuestId");

                    b.HasIndex("UserUuid", "QuestId")
                        .IsUnique();

                    b.ToTable("UsersQuests");
                });

            modelBuilder.Entity("ReQuests.Domain.Relations.UserRoleRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserUuid")
                        .IsRequired()
                        .HasColumnType("character varying(24)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserUuid", "RoleId")
                        .IsUnique();

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.TokenModel", b =>
                {
                    b.HasOne("ReQuests.Domain.Models.UserModel", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserUuid")
                        .HasPrincipalKey("Uuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReQuests.Domain.Relations.UserQuestRelation", b =>
                {
                    b.HasOne("ReQuests.Domain.Models.QuestModel", "Quest")
                        .WithMany("UsersR")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReQuests.Domain.Models.UserModel", "User")
                        .WithMany("QuestsR")
                        .HasForeignKey("UserUuid")
                        .HasPrincipalKey("Uuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReQuests.Domain.Relations.UserRoleRelation", b =>
                {
                    b.HasOne("ReQuests.Domain.Models.RoleModel", "Role")
                        .WithMany("UsersR")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReQuests.Domain.Models.UserModel", "User")
                        .WithMany("RolesR")
                        .HasForeignKey("UserUuid")
                        .HasPrincipalKey("Uuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.QuestModel", b =>
                {
                    b.Navigation("UsersR");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.RoleModel", b =>
                {
                    b.Navigation("UsersR");
                });

            modelBuilder.Entity("ReQuests.Domain.Models.UserModel", b =>
                {
                    b.Navigation("QuestsR");

                    b.Navigation("RolesR");

                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
