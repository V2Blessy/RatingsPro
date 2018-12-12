using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RatingsPro.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult TestLogin()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> CallApi()
        {
            var token = (User as ClaimsPrincipal).FindFirst("access_token").Value;

            var client = new HttpClient();
            client.SetBearerToken(token);

            var result = await client.GetStringAsync("apiurl" + "identity");
            ViewBag.Json = JArray.Parse(result.ToString());

            return View();
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public void SignoutCleanup(string sid)
        {
            var cp = (ClaimsPrincipal)User;
            var sidClaim = cp.FindFirst("sid");
            if (sidClaim != null && sidClaim.Value == sid)
            {
                Request.GetOwinContext().Authentication.SignOut("Cookies");
            }
        }
    }
}