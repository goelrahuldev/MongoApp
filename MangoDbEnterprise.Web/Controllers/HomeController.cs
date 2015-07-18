using System.Web.Mvc;

namespace MangoDbEnterprise.Web.Controllers
{
    public class HomeController : MangoDbEnterpriseControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}