namespace jspmdnx.Controllers
{
    using Microsoft.AspNet.Mvc;

    [Route("[controller]")]
    public class ErrorController : Controller
    {
        public IActionResult Error(int statusCode, string status)
        {
            this.Response.StatusCode = statusCode;

            ActionResult result = this.View("Error", statusCode);;
            return result;
        }
    }
}
