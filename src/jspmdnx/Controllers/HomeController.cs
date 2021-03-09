namespace jspmdnx.Controllers
{
    using jspmdnx.Constants;
    using Microsoft.AspNetCore.Mvc;


    public class HomeController : Controller
    {
        [HttpGet("", Name = HomeControllerRoute.GetIndex)]
        [AllowAnonymous()]
        public IActionResult Index() => View(HomeControllerAction.Index);

        [HttpGet("about", Name = HomeControllerRoute.GetAbout)]
        [AllowAnonymous()]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View(HomeControllerAction.About);
        }

        [HttpGet("contact", Name = HomeControllerRoute.GetContact)]
        [AllowAnonymous()]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View(HomeControllerAction.Contact);
        }
    }
}