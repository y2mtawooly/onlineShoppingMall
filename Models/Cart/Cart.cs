using OnlineShoppingMall.Models.Good;
using OnlineShoppingMall.Models.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static OnlineShoppingMall.Data.DataSet1;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShoppingMall.Models.Cart
{
    public class Cart
    {
        private int id;
        private int userAccountId;
        private int goodsId;
        private int saleId;
        private int consumptionTaxId;
        private DateTime addDate;
        private string addBy;
        private string updateBy;


        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int GoodsId { get; set; }
        public int SaleId { get; set; }
        public int ConsumptionTaxId { get; } = 0;
        public DateTime AddDate { get; } = DateTime.Now;
        public string AddBy { get; set; }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get; set; }

        public Cart()
        {
        }

        public Cart(DataRow row)
        {
            Id = int.Parse(row[0].ToString());
            UserAccountId = int.Parse(row[1].ToString());
            GoodsId = int.Parse(row[2].ToString());
            SaleId = int.Parse(row[3].ToString());
            ConsumptionTaxId = int.Parse(row[4].ToString());
            AddDate = DateTime.Parse(row[5].ToString());
            AddBy = row[6].ToString();
            UpdateDate = DateTime.Parse(row[7].ToString());
            UpdateBy = row[8].ToString();
        }
    }
}