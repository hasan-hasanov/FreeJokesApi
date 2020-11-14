using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.Database.Configurations
{
    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JokeId)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.JokePart)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(x => x.Joke)
                .WithMany(x => x.JokeParts);
        }
    }
}
