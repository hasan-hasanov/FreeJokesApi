using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Joke : IEntity<string>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }
    }
}
