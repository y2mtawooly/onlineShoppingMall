
using OnlineShoppingMall.Adapters;
using OnlineShoppingMall.Models.Cart;
using OnlineShoppingMall.Models.Good;
using OnlineShoppingMall.Models.UserInformation;
using System.Collections.Generic;
using System.Data;
using System.Web.DynamicData;
using System.Web.Services.Description;

namespace OnlineShoppingMall.Services
{
    public class GoodsService
    {
        private GoodsAdapter goodsAdapter;

        private GoodsAdapter Adapter { get { if (goodsAdapter == null) { goodsAdapter = new GoodsAdapter(); } return goodsAdapter; } }

        public DataTable GetAllData()
        {
            DataTable dataTable = Adapter.GetDataByAll();

            return dataTable;
        }
        public DataTable InsertGoodsData(Goods goods)
        {
            return Adapter.InsertGoodsData(goods);

        }
    }
}