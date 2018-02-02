using Application.Categories.Models;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FreeJokesApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;

        public CategoriesController(IGetAllCategoriesQuery getAllCategoriesQuery)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            List<CategoryModel> categories = _getAllCategoriesQuery.Execute();

            return Json(categories);
        }
    }
}
