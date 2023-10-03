using Adapter.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Adapter.EntityTypeConfiguration
{
    internal class ChatroomEntityTypeConfiguration : IEntityTypeConfiguration<Chatroom>
    {
        public void Configure(EntityTypeBuilder<Chatroom> builder)
        {
            builder.ToTable("chatroom");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.ChatroomName).IsRequired().HasColumnType("nvarchar(20)").HasDefaultValue("");
        }
    }
}
