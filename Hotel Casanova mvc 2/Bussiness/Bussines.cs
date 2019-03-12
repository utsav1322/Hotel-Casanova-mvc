using Hotel_Casanova_mvc_2.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;

namespace Hotel_Casanova_mvc.Bussiness
{
    public class Bussines
    {
        private String str;

       //private SqlCommand cmd = null;
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=UserDetails;Integrated Security=True");
        private string msg = string.Empty;

        public string validateUser(User Model)
        {
            try
            {
               /* string base64 = Model.Avatar;
                Byte[] bitmapData = new Byte[base64.Length];
                bitmapData = Convert.FromBase64String(FixBase64ForImage(base64));
*/
                //string result = "Invalid Email Address ....";
                conn.Open();
                str = "select count(*) FROM [Users] Where username='" + Model.UserName + "' or Email='" + Model.Email + "' or  Mobile='" + Model.Mobile + "' ";
                SqlCommand cmd = new SqlCommand(str, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    msg = "Sorry! you HAve dublicat data in UserName/Email/Number   .........User Details  Not Inserted Successfully!";
                }
                else
                {
                    var file = Model.postedFile;
                    byte[] imagebyte = null;
                    file.SaveAs(HttpContext.Current.Server.MapPath("/UploadImage/" + file.FileName));
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    imagebyte = reader.ReadBytes(file.ContentLength);




                    cmd = new SqlCommand("insert into Users  (UserName,FirstName,LastName,Email,Mobile,Password,CreatedDate,Status,Avatar,Type) " +
                                       "VALUES " +
                                       "(@UserName,@FirstName,@LastName,@Email,@Mobile,@Password,@CreatedDate,@Status,@Avatar,@Type)", conn);
                    
                    /*
                    cmd = new SqlCommand("insert into Users  (UserName,FirstName,LastName,Email,Mobile,Password,CreatedDate,Status,Type) " +
                                      "VALUES " +
                                      "(@UserName,@FirstName,@LastName,@Email,@Mobile,@Password,@CreatedDate,@Status,@Type)", conn);

                     */

                    cmd.Parameters.AddWithValue("@UserName", Model.UserName);
                    cmd.Parameters.AddWithValue("@FirstName", Model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", Model.LastName);
                    cmd.Parameters.AddWithValue("@Email", Model.Email);
                    cmd.Parameters.AddWithValue("@Mobile", Model.Mobile);
                    cmd.Parameters.AddWithValue("@Password", Model.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Status", "Active");

                    //  cmd.Parameters.AddWithValue("@Avatar", "Active");
                    //  cmd.Parameters.AddWithValue("@Avatar", (pic != null && pic.Length > 0) ? pic : null);

                    /*
                                   SqlParameter picparameter = new SqlParameter();
                                   picparameter.SqlDbType = SqlDbType.Image;
                                   picparameter.ParameterName = "pic";
                                   picparameter.Value = bitmapData;

                                   cmd.Parameters.AddWithValue ("@Avatar", (picparameter != null && picparameter.Size > 0) ? picparameter : null);

                   */
                    Model.Avatar = imagebyte;
                    cmd.Parameters.AddWithValue("@Avatar", Model.Avatar);
                    cmd.Parameters.AddWithValue("@Type", "User");

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    msg = "User Details Inserted Successfully";

                    //    Response.Redirect("Login.aspx");
                }
                // return Json(msg, JsonRequestBehavior.AllowGet);
                return msg;
            }
            catch (Exception e)
            {
                msg = "Error!!!" + e;
                // return Json(msg, JsonRequestBehavior.AllowGet);
                return msg;
            }
        }

        public string LoginUser(User Model)
        {
            try
            {
                conn.Open();
                str = "select count(*) FROM [Users] Where UserName='" + Model.UserName + "' and Password='" + Model.Password + "' ";
                SqlCommand cmd = new SqlCommand(str, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                   cmd = new SqlCommand("UPDATE Users SET [LastLoginDate] = @LastLoginDate  Where username='" + Model.UserName + "' ", conn);

                    cmd.Parameters.AddWithValue("@LastloginDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));

                    cmd.ExecuteNonQuery();


                    str = "select Type FROM [Users] Where UserName='" + Model.UserName + "' and Password='" + Model.Password + "' ";
                    cmd = new SqlCommand(str, conn);
                    string Type = Convert.ToString( cmd.ExecuteScalar());
                    //Type = "Admin";
                    if (Type == "Admin")
                    {
                        msg = "Admin_Login_Successful";
                    }
                    else {
                        msg = "User_Login_Successful";

                    }
                }
                else
                {
                    conn.Close();
                    msg = "Fail";
                }

                return msg;
            }
            catch (Exception e)
            {
                
                msg = "Error!!!" + e;
                conn.Close();
                // return Json(msg, JsonRequestBehavior.AllowGet);
                return msg;

            }
        }


        //public static string FixBase64ForImage(string image)
        //{
        //    StringBuilder sbText = new StringBuilder(image, image.Length);
        //    sbText.Replace("\r\n", String.Empty);
        //    sbText.Replace(" ", String.Empty);
        //    return sbText.ToString();
        //}
    }
}