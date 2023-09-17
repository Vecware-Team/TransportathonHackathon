using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages").HasKey(e => e.Id);

            builder.Property(e=>e.Id).HasColumnName("Id");
            builder.Property(e=>e.SenderId).HasColumnName("SenderId");
            builder.Property(e=>e.ReceiverId).HasColumnName("ReceiverId");
            builder.Property(e=>e.MessageText).HasColumnName("MessageText");
            builder.Property(e=>e.SendDate).HasColumnName("SendDate");
            builder.Property(e=>e.IsRead).HasColumnName("IsRead");
            builder.Property(e=>e.Queue).HasColumnName("Queue");

            builder.HasOne(e => e.Sender);
            builder.HasOne(e => e.Receiver);
        }
    }
}
