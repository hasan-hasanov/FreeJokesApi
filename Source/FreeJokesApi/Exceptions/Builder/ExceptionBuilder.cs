using FreeJokesApi.Exceptions.Builder.Abstract;
using FreeJokesApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;

namespace FreeJokesApi.Exceptions.Builder
{
    public class ExceptionBuilder : IExceptionBuilder
    {
        private const string DefaultErrorMessage = "A server error occurred.";

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
                error.Message = DefaultErrorMessage;
                error.Details = ex.Message;
            }

            return error;
        }
    }
}
