using OnlineShoppingMall.Models.Cart;
using OnlineShoppingMall.Models.Good;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Services;
using System;
using System.Web.Mvc;

namespace OnlineShoppingMall.Controllers
{
    public class GoodsController : Controller
    {

        private GoodsService goodsService;
        private GoodsService Service { get { if (goodsService == null) { goodsService = new GoodsService(); } return goodsService; } }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertGoodsData(FormCollection form)
        {
            Goods goods = new Goods();

            string name = form["userId"];
            string explanation = form["password"];
            string price = form["password"];
            string stock = form["password"];
            string categoryId = form["password"];
            string stardDate = form["password"];
            string endDate = form["password"];

            goods.Name = name;
            goods.Explanation = explanation;
            goods.Price = int.Parse(price);
            goods.Stock = int.Parse(stock);
            goods.CategoryId = int.Parse(categoryId);
            goods.StardDate = DateTime.Parse(stardDate);
            goods.EndDate = DateTime.Parse(endDate);

            var data = Service.InsertGoodsData(goods);

            return View();
        }
    }
}