﻿using Adapter.DBModel;
using Adapter.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Adapter
{
    public class ChatroomDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Chatroom> Chatroom { get; set; }
        public DbSet<Message> Message { get; set; }

        public ChatroomDBContext(DbContextOptions<ChatroomDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChatroomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
        }
    }
}