using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace OnlineShoppingMall.Models.Good
{
    public class Goods
    {
        private int id;
        private string name;
        private string explanation;
        private int price;
        private int stock;
        private int categoryId;
        private int softDelete;
        private DateTime stardDate;
        private DateTime endDate;
        private DateTime addDate;
        private string addBy;
        private string updateBy;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int SoftDelete { get; set; }
        public DateTime StardDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AddDate { get; } = DateTime.Now;
        public string AddBy { get; set; }
        public DateTime UpdateDate { get; } = DateTime.Now;
        public string UpdateBy { get; set; }

    }
}