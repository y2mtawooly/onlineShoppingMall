using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShoppingMall.Models.User
{
    public class UserInfo
    {
        private string id;
        private string name;
        private DateTime birth;
        private string gender;
        private string email;
        private string phoneNumber;
        private string postNumber;
        private string address;
        private DateTime addDate;

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
            id = row[0].ToString();
            name = row[1].ToString();
            birth = DateTime.Parse(row[2].ToString());
            Gender = row[3].ToString();
            Email = row[4].ToString();
            PhoneNumber = row[5].ToString();
            PostNumber = row[6].ToString();
            Address = row[7].ToString();
            AddDate = DateTime.Parse(row[8].ToString());
            UpdateDate = DateTime.Parse(row[9].ToString());
        }

        
    }
}