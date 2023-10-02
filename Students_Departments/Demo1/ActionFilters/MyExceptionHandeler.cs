using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo1.ActionFilters
{
    public class MyExceptionHandeler: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName = "error01"};
            }
           
            base.OnActionExecuted(context);
        }
    }
}
