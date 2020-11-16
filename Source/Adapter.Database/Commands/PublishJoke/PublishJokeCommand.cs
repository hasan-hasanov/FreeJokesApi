using Core.Commands;
using System.Collections.Generic;

namespace Adapter.Database.Commands.PublishJoke
{
    public class PublishJokeCommand : ICommand
    {
        public PublishJokeCommand(
            string category,
            IList<string> parts,
            IList<string> flags)
        {
            Category = category;
            Parts = parts;
            Flags = flags;
        }

        public string Category { get; }

        public IList<string> Parts { get; }

        public IList<string> Flags { get; }
    }
}
