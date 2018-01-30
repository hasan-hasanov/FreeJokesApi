using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Serializers.Abstract
{
    public interface IDataSerializer
    {
        List<Category> SerializerCategories();

        List<Joke> SerializeJokes();
    }
}
