
using Newtonsoft.Json;
using OnlineShoppingMall.Adapters;
using OnlineShoppingMall.Models.User;
using OnlineShoppingMall.Models.UserInformation;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;

namespace OnlineShoppingMall.Services
{
    public class LoginService
    {
        private LoginAdapter loginAdapter;

        private LoginAdapter Adapter { get { if (loginAdapter == null) { loginAdapter = new LoginAdapter(); } return loginAdapter; } }

        public DataTable GetAllData()
        {
            DataTable dataTable = Adapter.GetDataByAll();

            return dataTable;
        }

        public DataTable AddUserAccount(UserAccount userAccount)
        {
            DataTable dataTable = Adapter.AddUserAccount(userAccount);

            return dataTable;
        }

        public DataTable AddUserAccountInfo(UserInfo userInfo)
        {
            DataTable dataTable = Adapter.AddUserAccountInfo(userInfo);

            return dataTable;
        }
    }
}