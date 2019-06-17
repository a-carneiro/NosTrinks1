using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NosTrinks.Domain;

namespace NosTrinks.Context.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IsAdmin)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
