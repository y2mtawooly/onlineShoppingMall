
using Newtonsoft.Json;
using OnlineShoppingMall.Adapters;
using OnlineShoppingMall.Models.Cart;
using OnlineShoppingMall.Models.UserInformation;
using System.Collections.Generic;
using System.Data;
using System.Web.DynamicData;
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

        public DataTable InsertCart(Cart cart)
        {
            return Adapter.InsertCart(cart);

        }

        public DataTable Cart(int userId)
        {

            return Adapter.Cart(userId);

        }

        public DataTable AllDelete()
        {
            var dataTable = Adapter.AllDelete();

            return dataTable;

        }

        public string Delete(Cart cart)
        {
            var dataTable = Adapter.Delete(cart);

            var data = new List<Cart>();
            foreach (DataRow row in dataTable.Rows)
            {
                data.Add(new Cart(row));
            }

            string json = JsonConvert.SerializeObject(data);

            return json;
        }
    }
}