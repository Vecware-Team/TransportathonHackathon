using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(e => e.UserId);

            builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();

            builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(e => e.AppUser);
        }
    }
}
