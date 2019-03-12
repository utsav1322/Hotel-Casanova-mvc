using Hotel_Casanova_mvc.Bussiness;
using Hotel_Casanova_mvc_2.Models;
using System.Web.Mvc;

namespace Hotel_Casanova_mvc_2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User Model)
        {
            string result;
            Bussines bussinessobj = new Bussines();
            /* if (ModelState.IsValid)
             {
                  result = bussinessobj.validateUser(Model);
                 //ViewBag.Success = result;
             }*/
            result = bussinessobj.validateUser(Model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}