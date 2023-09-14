using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class PickupTruckConfiguration : IEntityTypeConfiguration<PickupTruck>
    {
        public void Configure(EntityTypeBuilder<PickupTruck> builder)
        {
            builder.ToTable("PickupTrucks").HasKey(e => e.VehicleId);
            builder.Property(e => e.VehicleId).HasColumnName("VehicleId").IsRequired();
            builder.Property(e => e.Size).HasColumnName("Size").IsRequired();

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);

            builder.HasOne(e => e.Vehicle);
        }
    }
}
