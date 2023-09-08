using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(e => e.Id);

            builder.Property(e => e.GloballyName).HasColumnName("GloballyName").IsRequired();
            builder.Property(e => e.LocallyName).HasColumnName("LocallyName").IsRequired();
            builder.Property(e => e.Code).HasColumnName("Code").IsRequired();

            builder.HasMany(e => e.Translates);
        }
    }
}
