using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(e => e.TransportRequestId);
            builder.Property(e => e.TransportRequestId).HasColumnName("TransportRequestId").IsRequired();
            builder.Property(e => e.Title).HasColumnName("Title").IsRequired();
            builder.Property(e => e.Description).HasColumnName("Description");
            builder.Property(e => e.Point).HasColumnName("Point").IsRequired();

            builder.HasOne(e => e.TransportRequest);
        }
    }
}
