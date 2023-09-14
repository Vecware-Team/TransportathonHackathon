using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(e => e.Company);

            builder.HasOne(e => e.Customer);

            builder.HasOne(e => e.Employee);

            builder.HasMany(e => e.Messages);
        }
    }
}
