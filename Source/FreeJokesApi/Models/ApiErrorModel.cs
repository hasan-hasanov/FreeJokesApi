using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FreeJokesApi.Models
{
    public sealed class ApiErrorModel
    {
        public string Message { get; set; }

        public string Details { get; set; }
    }
}
