using Application.Abstract;
using Application.Categories.Models;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Application.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQuery : IGetAllCategoriesQuery
    {
        private readonly IJokeService _jokeService;

        public GetAllCategoriesQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public List<CategoryModel> Execute()
        {
            return _jokeService.Categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Description
            }).ToList();
        }
    }
}
