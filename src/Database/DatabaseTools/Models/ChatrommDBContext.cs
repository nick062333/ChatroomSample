﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTools.Models;

public partial class ChatrommDBContext : DbContext
{
    public ChatrommDBContext(DbContextOptions<ChatrommDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chatroom> Chatroom { get; set; }

    public virtual DbSet<ChatroomMember> ChatroomMember { get; set; }

    public virtual DbSet<MessageLog> MessageLog { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chatroom>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("getdate()")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ChatroomMember>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ChatroomId });

            entity.Property(e => e.EntryTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<MessageLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Message");

            entity.HasIndex(e => e.GroupId, "IX_GroupId");

            entity.Property(e => e.Message)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.SendTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.LastLoginTime).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(20);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}