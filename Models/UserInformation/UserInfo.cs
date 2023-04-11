using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShoppingMall.Models.User
{
    public class UserInfo
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostNumber { get; set; }
        public string Address { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public UserInfo()
        {
        }
        public UserInfo(DataRow row)
        {
            Id = row["Id"].ToString();
            Name = row["Name"].ToString();
            Birth = DateTime.Parse(row["Birth"].ToString());
            Gender = row["Gender"].ToString();
            Email = row["Email"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            PostNumber = row["PostNumber"].ToString();
            Address = row["Address"].ToString();
            AddDate = DateTime.Parse(row["AddDate"].ToString());
            UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
        }

        
    }
}