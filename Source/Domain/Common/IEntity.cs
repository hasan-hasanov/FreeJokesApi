using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
