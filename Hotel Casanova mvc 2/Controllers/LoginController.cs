using Hotel_Casanova_mvc.Bussiness;
using Hotel_Casanova_mvc_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Casanova_mvc_2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckValidUser(User Model)
        {

            string result;
            Bussines bussinessobj = new Bussines();
            result = bussinessobj.LoginUser(Model);

            Session["UserName"] = Model.UserName.ToString();
            Session["Password"] = Model.Password.ToString();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Welcome()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AdminWelcome()
        {
            if (Session["UserName"] != null)
            {

                String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=UserDetails;Integrated Security=True";
                String sql = "SELECT * FROM Users";

                var model = new List<User>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var student = new User();
                        student.FirstName = Convert.ToString( rdr["FirstName"]);
                        student.LastName = Convert.ToString(rdr["LastName"]);
                        student.Avatar = Encoding.UTF8.GetBytes(rdr["Avatar"].ToString());

                        //student.Class = rdr["Class"];


                        model.Add(student);
                    }

                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}