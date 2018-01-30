using Application.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Categories.Queries.GetAllCategoriesQuery.Abstract
{
    public interface IGetAllCategoriesQuery
    {
        List<CategoryModel> Execute();
    }
}
