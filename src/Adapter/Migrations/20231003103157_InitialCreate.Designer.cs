﻿// <auto-generated />
using System;
using Adapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Adapter.Migrations
{
    [DbContext(typeof(ChatroomDBContext))]
    [Migration("20231003103157_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Adapter.DBModel.Chatroom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChatroomName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("chatroom", (string)null);
                });

            modelBuilder.Entity("Adapter.DBModel.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ChatroomId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_id");

                    b.Property<string>("ConnectionId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("connection_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("")
                        .HasColumnName("content");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("send_time");

                    b.HasKey("Id");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("Adapter.DBModel.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("")
                        .HasColumnName("account");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_time");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
