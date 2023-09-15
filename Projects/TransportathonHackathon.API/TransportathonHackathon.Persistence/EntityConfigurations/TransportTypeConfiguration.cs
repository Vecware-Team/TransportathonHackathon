using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class TransportTypeConfiguration : IEntityTypeConfiguration<TransportType>
    {
        public void Configure(EntityTypeBuilder<TransportType> builder)
        {
            builder.ToTable("TransportTypes").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.Type).HasColumnName("Type").IsRequired();

            builder.HasMany(e => e.TransportRequests);
        }
    }
}
