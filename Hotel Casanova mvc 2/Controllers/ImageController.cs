using Hotel_Casanova_mvc_2.Bussiness;
using Hotel_Casanova_mvc_2.Models;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel_Casanova_mvc_2.Controllers
{
    public class ImageController : Controller
    {
       /* private String str;

        private SqlCommand cmd = null;
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=UserDetails;Integrated Security=True");
        private string msg = string.Empty;*/

        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImageUpload(User model)
        {

            ImageUpload imageUploadobj = new ImageUpload();
            string imgId = imageUploadobj.UploadImg(model);

            return Json(imgId, JsonRequestBehavior.AllowGet);
        }
        //[NonAction]
        //public ActionResult SettingImage(User model)
        //{
        //    if (Session["UserName"] != null)
        //    {
        //        ImageUpload imageUploadobj = new ImageUpload();


        //    }

        //}
        
    }
}