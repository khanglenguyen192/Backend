using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ILogger<BaseController> _logger;

        public BaseController(IWebHostEnvironment webHostEnvironment, ILogger<BaseController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
    }
}
