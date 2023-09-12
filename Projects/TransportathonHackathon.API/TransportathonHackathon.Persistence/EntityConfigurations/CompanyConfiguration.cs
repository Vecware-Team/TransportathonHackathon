using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies").HasKey(e => e.AppUserId);

            builder.Property(e => e.CompanyName).HasColumnName("CompanyName").IsRequired();
            builder.Property(e => e.DriverCount).HasColumnName("DriverCount").IsRequired();
            builder.Property(e => e.CompletedJobsCount).HasColumnName("CompletedJobsCount").IsRequired();

            builder.HasOne(e => e.AppUser);
            builder.HasMany(e => e.Employees);
            builder.HasMany(e => e.Vehicles);
            builder.HasMany(e => e.TransportRequests);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
