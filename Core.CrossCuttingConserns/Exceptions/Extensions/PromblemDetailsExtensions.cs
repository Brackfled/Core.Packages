using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Exceptions.Extensions
{
    public static class PromblemDetailsExtensions
    {

        public static string AsJson<TProblemDetail>(this TProblemDetail detail)
            where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(detail);

    }
}
