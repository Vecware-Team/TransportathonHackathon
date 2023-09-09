using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CarrierConfiguration : IEntityTypeConfiguration<Carrier>
    {
        public void Configure(EntityTypeBuilder<Carrier> builder)
        {
            builder.ToTable("Carriers").HasKey(e => e.EmployeeId);

            builder.HasOne(e => e.AppUser);
            builder.HasOne(e => e.Employee);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
