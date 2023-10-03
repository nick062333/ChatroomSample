using Adapter.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EntityTypeConfiguration
{
    internal class ChatroomMemberEntityTypeConfiguration : IEntityTypeConfiguration<ChatroomMember>
    {
        public void Configure(EntityTypeBuilder<ChatroomMember> builder)
        {
            builder.ToTable("chatroom_member");
            builder.Property(b => b.ChatroomId).IsRequired().HasColumnName("chatroom_id");
            builder.Property(b => b.UserId).IsRequired().HasColumnName("user_id");
            builder.Property(b => b.EntryTime).HasColumnName("entry_time").IsRequired();
            builder.HasAlternateKey(e => new { e.ChatroomId, e.UserId });
        }
    }
}