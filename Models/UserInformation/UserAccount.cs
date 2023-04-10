using System;
using System.Data;

namespace OnlineShoppingMall.Models.UserInformation
{
    public class UserAccount
    {

        private int id;
        private string userId;
        private string password;
        private DateTime addDate;
        private string addBy;
        private string updateBy;


        //get은 받는거. set은 외부에서 설정할 수 있게하는거.
        public int Id {  get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public string AddBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; }

        public UserAccount()
        {
        }

        public UserAccount(DataRow row)
        {
            Id = int.Parse(row[0].ToString());
            UserId = row[1].ToString();
            Password = row[2].ToString();
        }
    }
}
