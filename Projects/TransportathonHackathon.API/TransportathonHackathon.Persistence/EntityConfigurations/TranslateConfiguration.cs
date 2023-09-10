using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class TranslateConfiguration : IEntityTypeConfiguration<Translate>
    {
        public void Configure(EntityTypeBuilder<Translate> builder)
        {
            builder.ToTable("Translates").HasKey(e=>e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(e => e.Key).HasColumnName("Key").IsRequired();
            builder.Property(e => e.Value).HasColumnName("Value").IsRequired();

            builder.HasOne(e => e.Language);

            builder.Ignore(e => e.CreatedDate);
            builder.Ignore(e => e.UpdatedDate);
            builder.Ignore(e => e.DeletedDate);
        }
    }
}
