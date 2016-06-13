namespace jspmdnx.Controllers
{
    using jspmdnx.Constants;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet("{statusCode:int:range(400, 599)}/{status?}", Name = ErrorControllerRoute.GetError)]
        public IActionResult Error(int statusCode, string status)
        {
            this.Response.StatusCode = statusCode;

            ActionResult result = this.View(ErrorControllerAction.Error, statusCode);;
            return result;
        }
    }
}
