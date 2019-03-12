using Hotel_Casanova_mvc_2.Models;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace Hotel_Casanova_mvc_2.Bussiness
{
    public class ImageUpload
    {
        //private String str;

      //  private  = null;
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=UserDetails;Integrated Security=True");
        private string msg = string.Empty;

        public string UploadImg(User Model)
        {
            try
            {
                conn.Open();
                if (Model.postedFile != null)
                {
                    var file = Model.postedFile;
                    byte[] imagebyte = null;
                    file.SaveAs(HttpContext.Current.Server.MapPath("/UploadImage/" + file.FileName));
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    imagebyte = reader.ReadBytes(file.ContentLength);

                    SqlCommand  cmd = new SqlCommand("Insert into [Users] (Avatar) VALUES (@Avatar) ", conn);
                    Model.Avatar = imagebyte;
                    cmd.Parameters.AddWithValue("@Avatar", Model.Avatar);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg = "User Details Inserted Successfully";
                }
                return msg;
            }
            catch (Exception e)
            {
                msg = "Error!!!";
                return msg;
            }
        }
    }
}