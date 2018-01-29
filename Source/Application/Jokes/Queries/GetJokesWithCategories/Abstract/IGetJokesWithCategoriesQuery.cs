using System.Collections.Generic;

namespace Application.Jokes.Queries.GetJokesWithCategories.Abstract
{
    public interface IGetJokesWithCategoriesQuery
    {
        List<JokeModel> Execute();
    }
}
