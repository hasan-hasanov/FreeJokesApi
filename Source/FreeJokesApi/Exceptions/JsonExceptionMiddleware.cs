using FreeJokesApi.Exceptions.Abstract;
using FreeJokesApi.Exceptions.Builder.Abstract;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FreeJokesApi.Exceptions
{
    public sealed class JsonExceptionMiddleware : IJsonExceptionMiddleware
    {
        private readonly IHostingEnvironment _env;
        private readonly IExceptionBuilder _exceptionBuilder;
        private readonly JsonSerializer _serializer;

        public JsonExceptionMiddleware(IHostingEnvironment env,
            IExceptionBuilder exceptionBuilder,
            JsonSerializer serializer)
        {
            _env = env;
            _exceptionBuilder = exceptionBuilder;

            _serializer = serializer;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) return;

            var error = _exceptionBuilder.BuildException(ex, _env);

            using (var writer = new StreamWriter(context.Response.Body))
            {
                _serializer.Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
