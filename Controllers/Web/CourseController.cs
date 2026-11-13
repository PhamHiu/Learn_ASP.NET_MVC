using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers.Web
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
