namespace jspmdnx.Controllers
{
    using Microsoft.AspNet.Mvc;

    public class HomeController : Controller
    {
        [HttpGet("", Name = "Home.GetIindex")]
        public IActionResult Index() => View("Index");

        [HttpGet("about", Name = "Home.GetAbout")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View("About");
        }

        [HttpGet("contact", Name = "Home.GetContact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View("Contact");
        }
    }
}