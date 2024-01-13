using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Exceptions.HttpProblemDetails
{
    public class AuthorizationProblemDetails: ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Auth Error!";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
            Type = "https://example/probs/unauthorization";
        }
    }
}
