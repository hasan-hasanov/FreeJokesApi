using FreeJokesApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;

namespace FreeJokesApi.Exceptions.Builder.Abstract
{
    public interface IExceptionBuilder
    {
        ApiErrorModel BuildException(Exception ex, IHostingEnvironment env);
    }
}
