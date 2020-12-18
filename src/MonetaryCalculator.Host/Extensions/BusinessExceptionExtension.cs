using Microsoft.AspNetCore.Mvc;
using MonetaryCalculator.Domain;
using System.Collections.Generic;

namespace MonetaryCalculator.Host.Extensions
{
    public static class BusinessExceptionExtension
    {
        public static ActionResult GetError(this BusinessException exception)
        {
            var errors = new Dictionary<string, string[]>();
            errors.Add("businessError", new string[]
            {
                exception.Message
            });

            return new BadRequestObjectResult(new ValidationProblemDetails(errors));
        }
    }
}
