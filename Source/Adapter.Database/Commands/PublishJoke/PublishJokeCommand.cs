using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter.Database.Commands.PublishJoke
{
    public class PublishJokeCommand : ICommand
    {
        public PublishJokeCommand(
            string category,
            IList<string> parts,
            IList<string> flags)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException(nameof(category));
            }

            if (parts == null || !parts.Any())
            {
                throw new ArgumentException(nameof(parts));
            }

            Category = category;
            Parts = parts;
            Flags = flags;
        }

        public string Category { get; }

        public IList<string> Parts { get; }

        public IList<string> Flags { get; }
    }
}
