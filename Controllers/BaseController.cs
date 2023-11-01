using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HourTrackerBackend.Controllers
{
    public class BaseController : Controller
    {
        public Stopwatch sw = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            sw.Restart();
            base.OnActionExecuting(context);
        }

        //At end of request
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            List<string> ls = new List<string>()
            {
                $"Method: {context.HttpContext.Request.Method}",
                $"Time used: {sw.ElapsedMilliseconds}ms",
                $"Controller: {context.Controller.ToString().Split('.').LastOrDefault()}",
                $"Request: {context.HttpContext.Request.Path.Value}",
            };

            ls[0] = addSpacers(ls[0], 12);
            ls[1] = addSpacers(ls[1], 15);
            ls[2] = addSpacers(ls[2], 43);

            var tabbed = string.Join(' ', ls.Select(x => x + "\t"));

            Console.WriteLine(tabbed);
            base.OnActionExecuted(context);
        }
        private string addSpacers(string val, int length)
        {
            var newVal = val;
            if (val.Length < length)
            {
                for (int i = 0; i < (length - val.Length); i++)
                {
                    newVal = newVal + " ";
                }
            }
            return newVal;
        }
    }
}
