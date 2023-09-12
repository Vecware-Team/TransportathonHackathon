using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class TransportRequestConfiguration : IEntityTypeConfiguration<TransportRequest>
    {
        public void Configure(EntityTypeBuilder<TransportRequest> builder)
        {
            builder.ToTable("TransportRequests").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("CustomerId").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").IsRequired();
            builder.Property(e => e.CountryFrom).HasColumnName("CountryFrom").IsRequired();
            builder.Property(e => e.CountryTo).HasColumnName("CountryTo").IsRequired();
            builder.Property(e => e.CityFrom).HasColumnName("CityFrom").IsRequired();
            builder.Property(e => e.CityTo).HasColumnName("CityTo").IsRequired();
            builder.Property(e => e.IsOfficce).HasColumnName("IsOfficce").IsRequired();
            builder.Property(e => e.PlaceSize).HasColumnName("PlaceSize").IsRequired();
            builder.Property(e => e.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(e => e.FinishDate).HasColumnName("FinishDate");

            builder.HasOne(e => e.Customer);
            builder.HasOne(e => e.Company);
        }
    }
}
