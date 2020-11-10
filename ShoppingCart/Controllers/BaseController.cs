using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Web.ViewModels;

namespace ShoppingCart.Web.Controllers
{
    public class BaseController : Controller
    {
        public string GetSessionId()
        {
            //set an session value to initiate a session object otherwise session id chenges each request.
            var session = HttpContext.Session.GetString("sessionId");
            if (session == null)
                HttpContext.Session.SetString("sessionId", HttpContext.Session.Id);
            return HttpContext.Session.Id;
        }
    }


}
