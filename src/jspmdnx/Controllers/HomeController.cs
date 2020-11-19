namespace jspmdnx.Controllers
{
    using jspmdnx.Constants;
    using Microsoft.AspNetCore.Mvc;


    public class HomeController : Controller
    {
        [HttpGet("", Name = HomeControllerRoute.GetIndex)]
        public IActionResult Index() => View(HomeControllerAction.Index);

        [HttpGet("about", Name = HomeControllerRoute.GetAbout)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View(HomeControllerAction.About);
        }

        [HttpGet("contact", Name = HomeControllerRoute.GetContact)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View(HomeControllerAction.Contact);
        }
    }
}