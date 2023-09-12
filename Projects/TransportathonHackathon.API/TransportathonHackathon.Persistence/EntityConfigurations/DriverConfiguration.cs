using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers").HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").IsRequired();

            builder.HasOne(e => e.Employee);
            builder.HasOne(e => e.DriverLicense);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
