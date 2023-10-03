using Adapter.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EntityTypeConfiguration
{
    internal class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder) 
        {
            builder.ToTable("message");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.ChatroomId).HasColumnName("group_id").IsRequired();
            builder.Property(b => b.Content).HasColumnName("content").IsRequired().HasColumnType("nvarchar(max)").HasDefaultValue("");
            builder.Property(b => b.SendTime).HasColumnName("send_time").IsRequired();
        }
    }
}
