using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
