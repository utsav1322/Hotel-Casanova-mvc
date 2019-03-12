using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Casanova_mvc_2.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        //public string CreatedDate { get; set; }
        //public string LastLoginDate { get; set; }
        //public string Status { get; set; }
        public byte[] Avatar { get; set; }
        //public string Avatar { get; set; }
        //public HttpPostedFileWrapper ImageFile { get; set; }
        public HttpPostedFileWrapper postedFile { get; set; }

        //public Nullable<bool> IsValid { get; set; }
    }
}