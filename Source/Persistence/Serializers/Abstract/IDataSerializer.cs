using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.Serializers.Abstract
{
    public interface IDataSerializer
    {
        IEnumerable<Category> SerializerCategories();

        IEnumerable<Joke> SerializeJokes();
    }
}
