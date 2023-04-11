
using OnlineShoppingMall.Adapters;
using OnlineShoppingMall.Models.UserInformation;
using System.Collections.Generic;
using System.Data;
using System.Web.Services.Description;

namespace OnlineShoppingMall.Services
{
    public class HomeService
    {
        private HomeAdapter homeAdapter;

        private HomeAdapter Adapter { get { if (homeAdapter == null) { homeAdapter = new HomeAdapter(); } return homeAdapter; } }

        public DataTable GetAllData()
        {
            DataTable dataTable = Adapter.GetDataByAll();

            return dataTable;
        }

        public string Login(UserAccount userAccount)
        {
            var dataTable = Adapter.Login(userAccount);

            var data = new List<UserAccount>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new UserAccount(row));
            }

            var count = data.Count;

            if (count != 0)
            {
                var message = data[0].Id.ToString();
                return message;
            }
            else
            {
                var message = "IDまたはパスワードを再確認してください。";
                return message;
            }
            
        }

        public DataTable DetailGoodsInfo(string goodsId)
        {
            return Adapter.DetailGoodsInfo(goodsId);

        }

        public DataTable Cart(string goodsId)
        {
            return Adapter.Cart(goodsId);

        }
    }
}