using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.Database.Configurations
{
    public class JokeFlagConfig : IEntityTypeConfiguration<JokeFlag>
    {
        public void Configure(EntityTypeBuilder<JokeFlag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JokeId)
                .IsRequired();

            builder.Property(x => x.FlagId);

            builder.HasOne(x => x.Joke)
                .WithMany(x => x.JokeFlags);

            builder.HasOne(x => x.Flag)
                .WithMany(x => x.JokeFlags);
        }
    }
}
