using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HourTrackerBackend.Modals.Database;
using Microsoft.AspNetCore.Identity;
using HourTrackerBackend.Modals;

namespace HourTrackerBackend.Controllers
{
    public class BaseController : Controller
    {
        string errorMsg = "You need to pass IHttpContextAccessor to base if you want to autoinject properties in constructor";
        private HttpContext _httpContext;
        private TrackerContext _context;
        protected TrackerContext __context => _context ?? (_context = (HttpContext ?? _httpContext ?? throw new Exception(errorMsg)).RequestServices.GetService<TrackerContext>()!);
        private UserManager<User> _userManager;
        protected UserManager<User> __userManager => _userManager ?? (_userManager = (HttpContext ?? _httpContext ?? throw new Exception(errorMsg)).RequestServices.GetService<UserManager<User>>()!);
        private string _username;
        protected string __username => _username ?? (_username = (HttpContext ?? _httpContext ?? throw new Exception(errorMsg)).User.Identity?.Name!)!;
        private string _fromUrl;
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
        protected string __fromUrl => _fromUrl ??
            (
                _fromUrl = (HttpContext ?? _httpContext ?? throw new Exception(errorMsg))!.Request.Headers.Any(x => x.Key.ToLower() == "RefererWithSrc".ToLower()) ? (HttpContext ?? _httpContext)?.Request?.Headers?.FirstOrDefault(x => x.Key.ToLower() == "RefererWithSrc".ToLower())!.Value!.FirstOrDefault()! :
                _fromUrl = (HttpContext ?? _httpContext ?? throw new Exception(errorMsg))!.Request.Headers.Any(x => x.Key.ToLower() == "Referer".ToLower()) ? (HttpContext ?? _httpContext)?.Request?.Headers?.FirstOrDefault(x => x.Key.ToLower() == "Referer".ToLower()).Value.FirstOrDefault()! :
                null
            )!;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BaseController(IHttpContextAccessor httpContextAccessor)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _httpContext = httpContextAccessor.HttpContext!;            
        }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BaseController()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

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
                $"Controller: {context!.Controller!.ToString()!.Split('.').LastOrDefault()}",
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
