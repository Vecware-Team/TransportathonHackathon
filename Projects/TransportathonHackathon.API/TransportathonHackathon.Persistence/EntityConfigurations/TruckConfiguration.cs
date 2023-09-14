using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks").HasKey(e => e.VehicleId);
            builder.Property(e => e.VehicleId).HasColumnName("VehicleId").IsRequired();
            builder.Property(e => e.Size).HasColumnName("Size").IsRequired();

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);

            builder.HasOne(e => e.Vehicle);
        }
    }
}
