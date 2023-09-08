using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(e => e.AppUserId);

            builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate); 
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
