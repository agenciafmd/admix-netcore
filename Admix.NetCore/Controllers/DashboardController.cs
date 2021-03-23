using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admix.NetCore.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        public DashboardController()
        {

        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}