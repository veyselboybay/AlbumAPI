using Microsoft.AspNetCore.Mvc;

namespace Assignment_One_Revise.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
