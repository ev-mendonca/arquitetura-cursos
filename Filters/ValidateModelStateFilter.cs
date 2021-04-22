using Arquitetura_Curso_DIO.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Arquitetura_Curso_DIO.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var badRequestResponse = new BadRequestResponse(context.ModelState.Select(m => new BadRequestField(m.Key, m.Value.Errors.Select(e => e.ErrorMessage))));
                context.Result = new BadRequestObjectResult(badRequestResponse);
            }
        }

        
    }
}
