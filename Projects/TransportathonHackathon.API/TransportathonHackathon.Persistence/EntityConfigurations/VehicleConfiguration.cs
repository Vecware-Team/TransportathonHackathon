using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").IsRequired();
            builder.Property(e => e.DriverId).HasColumnName("DriverId");

            builder.HasOne(e => e.Car);
            builder.HasOne(e => e.Truck);
            builder.HasOne(e => e.PickupTruck);
            builder.HasOne(e => e.Driver);
            builder.HasOne(e => e.Company);
        }
    }
}
