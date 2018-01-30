using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.Serializers.Abstract
{
    public interface IDataSerializer
    {
        List<Category> SerializerCategories();

        List<Joke> SerializeJokes();
    }
}
