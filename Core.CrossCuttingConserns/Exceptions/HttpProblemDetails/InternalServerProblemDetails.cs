using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConserns.Exceptions.HttpProblemDetails
{
    public class InternalServerProblemDetails : ProblemDetails
    {

        public InternalServerProblemDetails(string detail)
        {
            Title = "Internal Server Error";
            Detail = "Internal Server Error";
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://excample.com/probs/business";
        }

    }
}
