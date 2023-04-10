
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

        
        public DataTable Login(UserAccount userAccount)
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
                return dataTable;
            }
            else
            {
                return null;
            }
            
        }
    }
}