
using Newtonsoft.Json;
using OnlineShoppingMall.Adapters;
using OnlineShoppingMall.Models.User;
using OnlineShoppingMall.Models.UserInformation;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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

        public string FindID(UserInfo userInfo)
        {
            DataTable dataTable = Adapter.FindId(userInfo);

            var data = new List<UserInfo>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new UserInfo(row));
            }

            var count = data.Count;

            var id = data[0].Id;
            var name = data[0].Name;

            if (count != 0)
            {
                var message = name + "様の    IDは、「" + id + "」です。";

                return message;
            }
            else
            {
                var message = "登録情報がありません。";
                return message;
            }
        }

        public string FindPassword(string id)
        {
            DataTable dataTable = Adapter.FindPassword(id);

            var data = new List<UserAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new UserAccount(row));
            }

            var count = data.Count;

            var userId = data[0].UserId;
            var password = data[0].Password;

            if (count != 0)
            {
                var message = userId + "様の    パスワードは、「" + password + "」です。";

                return message;
            }
            else
            {
                var message = "IDをもう一度ご確認お願いします。";
                return message;
            }
        }

    }
}