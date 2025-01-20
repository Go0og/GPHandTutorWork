
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace GPHandTutorWorkApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            if (APIclient.Tutor == null) {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Template() {
            if (APIclient.Tutor == null) {
                return Redirect("~/Home/Enter");
            }

            return View();
        }

        [HttpGet]
        public IActionResult TemplateCreate() {
            if (APIclient.Tutor == null) {
                return Redirect("~/Home/Enter");
            }

            return View(APIclient.Tutor);
        }



    }
}
