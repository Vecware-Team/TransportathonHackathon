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

            builder.HasOne(e => e.Carrier);
            builder.HasOne(e => e.Driver);
            builder.HasOne(e => e.AppUser);


            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
