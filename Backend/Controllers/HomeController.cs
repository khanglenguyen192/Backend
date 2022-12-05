using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        public HomeController(IWebHostEnvironment webHostEnvironment, ILogger<BaseController> logger) : base(webHostEnvironment, logger)
        {
        }
    }
}
