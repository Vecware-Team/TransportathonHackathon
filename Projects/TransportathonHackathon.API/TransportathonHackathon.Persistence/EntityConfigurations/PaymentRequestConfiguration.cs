using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class PaymentRequestConfiguration : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> builder)
        {
            builder.ToTable("PaymentRequests").HasKey(e => e.TransportRequestId);

            builder.Property(e => e.TransportRequestId).HasColumnName("TransportRequestId").IsRequired();
            builder.Property(e => e.IsPaid).HasColumnName("IsPaid").IsRequired();
            builder.Property(e => e.Price).HasColumnName("Price").IsRequired();

            builder.HasOne(e => e.TransportRequest);
        }
    }
}
