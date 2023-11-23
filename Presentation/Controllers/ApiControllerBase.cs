﻿using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }

            var statusCode = errors[0].Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError,
            };

            var problemDetails = (ProblemDetails?)Problem(statusCode: statusCode).Value;

            var dictionaryErrors = new Dictionary<string, List<string>>();
            foreach (var error in errors)
            {
                if (!dictionaryErrors.ContainsKey(error.Code))
                    dictionaryErrors.Add(error.Code, []);
                dictionaryErrors[error.Code].Add(error.Description);
            }

            problemDetails?.Extensions.Add("errors", dictionaryErrors);

            return new ObjectResult(problemDetails);
        }
    }
}
