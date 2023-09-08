using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class DriverLicenseConfiguration : IEntityTypeConfiguration<DriverLicense>
    {
        public void Configure(EntityTypeBuilder<DriverLicense> builder)
        {
            builder.ToTable("DriverLicenses").HasKey(e => e.DriverId);
            builder.Property(e => e.IsNew).HasColumnName("IsNew").IsRequired();
            builder.Property(e => e.LicenseGetDate).HasColumnName("LicenseGetDate").IsRequired();
            builder.Property(e => e.DriverId).HasColumnName("DriverId").IsRequired();
            builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(e => e.Classes).HasColumnName("Classes").IsRequired();

            builder.HasOne(e => e.Driver);
        }
    }
}
