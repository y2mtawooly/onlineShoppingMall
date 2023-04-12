using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}