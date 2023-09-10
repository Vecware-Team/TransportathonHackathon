using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(e => e.AppUserId);
            builder.Property(e => e.IsOnTransitNow).HasColumnName("IsOnTransitNow").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").IsRequired();
            builder.Property(e => e.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(e => e.Age).HasColumnName("Age").IsRequired();

            builder.HasOne(e => e.Carrier);
            builder.HasOne(e => e.Driver);
            builder.HasOne(e => e.AppUser);
            builder.HasOne(e => e.Company);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
