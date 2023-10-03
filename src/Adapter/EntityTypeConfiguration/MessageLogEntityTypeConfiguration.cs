using Adapter.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EntityTypeConfiguration
{
    internal class MessageLogEntityTypeConfiguration : IEntityTypeConfiguration<MessageLog>
    {
        public void Configure(EntityTypeBuilder<MessageLog> builder) 
        {
            builder.ToTable("message_log");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.ChatroomId).HasColumnName("group_id").IsRequired();
            builder.Property(b => b.Content).HasColumnName("content").IsRequired().HasColumnType("nvarchar(max)").HasDefaultValue("");
            builder.Property(b => b.SendTime).HasColumnName("send_time").IsRequired();
            builder.Property(b => b.SendUserId).HasColumnName("send_user_id").IsRequired();
            builder.Property(b => b.ToUserId).HasColumnName("to_user_id").IsRequired().HasDefaultValue("*");
        }
    }
}
