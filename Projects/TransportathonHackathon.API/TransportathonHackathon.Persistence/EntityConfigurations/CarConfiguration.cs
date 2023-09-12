using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(e => e.VehicleId);
            builder.Property(e => e.VehicleId).HasColumnName("VehicleId").IsRequired();
            builder.Property(e => e.Brand).HasColumnName("Brand").IsRequired();
            builder.Property(e => e.Model).HasColumnName("Model").IsRequired();
            builder.Property(e => e.ModelYear).HasColumnName("ModelYear").IsRequired();

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);

            builder.HasOne(e => e.Vehicle);
        }
    }
}
