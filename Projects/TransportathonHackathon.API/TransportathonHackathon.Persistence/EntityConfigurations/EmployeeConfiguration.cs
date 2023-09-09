using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.Carrier)
                    .WithOne(c => c.Employee)
                    .HasForeignKey<Carrier>(c => c.EmployeeId);
            builder.HasOne(e => e.Driver)
                    .WithOne(c => c.Employee)
                    .HasForeignKey<Driver>(c => c.EmployeeId);

            builder.HasOne(e => e.Company)
                    .WithMany(c => c.Employees);

            builder.ToTable("Employees").HasKey(e => e.AppUserId);
            builder.Property(e => e.IsOnTransitNow).HasColumnName("IsOnTransitNow").IsRequired();
            //builder.Property(e => e.CompanyId).HasColumnName("CompanyId").IsRequired();

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
