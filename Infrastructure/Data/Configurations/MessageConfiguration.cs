using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasOne(u => u.Recipient)
            .WithMany(r => r.MessageReceived)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(u => u.Sender)
            .WithMany(m => m.MessageSent)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(m => m.Files)
            .WithOne(m => m.Message)
            .HasForeignKey(m => m.MessageId);
    }
        
}
