using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class TestController : Controller
    {
        public string Demo()
        {
            return "hàm Demo() trong TestController - domain/<tên controller(bỏ hậu tố )> / <tên hàm> ";
        }
    }
}
