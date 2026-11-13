using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
