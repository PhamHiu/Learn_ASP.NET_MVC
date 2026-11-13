using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers.Web
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
