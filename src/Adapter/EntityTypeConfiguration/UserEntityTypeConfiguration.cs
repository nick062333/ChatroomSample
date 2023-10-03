using Adapter.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Adapter.EntityTypeConfiguration
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id").IsRequired();
            builder.Property(b => b.Account).HasColumnName("account").HasColumnType("varchar(20)").IsRequired().HasDefaultValue("");
            builder.Property(b => b.UserName).HasColumnName("user_name").HasColumnType("nvarchar(20)").IsRequired().HasDefaultValue("");
            builder.Property(b => b.CreateTime).HasColumnName("create_time").IsRequired();
        }
    }
}
