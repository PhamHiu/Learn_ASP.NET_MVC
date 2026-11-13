using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers.Web
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
