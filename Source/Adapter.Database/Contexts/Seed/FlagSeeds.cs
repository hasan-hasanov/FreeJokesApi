using Core.Entities;
using System.Collections.Generic;

namespace Adapter.Database.Contexts.Seed
{
    public class FlagSeeds
    {
        public FlagSeeds()
        {
            Flags = new List<Flag>()
            {
                new Flag() { Id = 1, Name = "NSFW" },
                new Flag() { Id = 2, Name = "Religious" },
                new Flag() { Id = 3, Name = "Political" },
                new Flag() { Id = 4, Name = "Racist" },
                new Flag() { Id = 5, Name = "Sexist" },
                new Flag() { Id = 6, Name = "Adult" },
            };
        }

        public List<Flag> Flags { get; }
    }
}
