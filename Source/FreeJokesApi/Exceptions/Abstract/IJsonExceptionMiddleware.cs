using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FreeJokesApi.Exceptions.Abstract
{
    public interface IJsonExceptionMiddleware
    {
        Task Invoke(HttpContext context);
    }
}
