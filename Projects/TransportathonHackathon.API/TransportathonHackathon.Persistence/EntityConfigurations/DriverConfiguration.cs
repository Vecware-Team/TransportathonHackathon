using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasOne(e => e.DriverLicense)
                    .WithOne(c => c.Driver)
                    .HasForeignKey<DriverLicense>(c => c.DriverId);

            builder.ToTable("Drivers").HasKey(e => e.EmployeeId);

            builder.HasOne(e => e.Employee);
            builder.HasOne(e => e.DriverLicense);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
