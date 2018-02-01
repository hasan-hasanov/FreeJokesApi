using Application.Categories.Models;
using System.Collections.Generic;

namespace Application.Categories.Queries.GetAllCategoriesQuery.Abstract
{
    public interface IGetAllCategoriesQuery
    {
        List<CategoryModel> Execute();
    }
}
