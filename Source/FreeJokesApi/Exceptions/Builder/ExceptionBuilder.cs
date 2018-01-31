using FreeJokesApi.Exceptions.Builder.Abstract;
using FreeJokesApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeJokesApi.Exceptions.Builder
{
    public class ExceptionBuilder : IExceptionBuilder
    {
        private const string DEFAULT_ERROR_MESSAGE = "A server error occurred.";

        public ApiErrorModel BuildException(Exception ex, IHostingEnvironment env)
        {
            var error = new ApiErrorModel();

            if (env.IsDevelopment())
            {
                error.Message = ex.Message;
                error.Details = ex.StackTrace;
            }
            else
            {
                error.Message = DEFAULT_ERROR_MESSAGE;
                error.Details = ex.Message;
            }

            return error;
        }
    }
}
