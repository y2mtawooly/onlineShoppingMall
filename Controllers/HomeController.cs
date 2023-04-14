using OnlineShoppingMall.Models.Cart;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace OnlineShoppingMall.Controllers
{
    public class HomeController : Controller
    {

        private HomeService homeService;
        private HomeService Service { get { if (homeService == null) { homeService = new HomeService(); } return homeService; } }
        public ActionResult Index()
        {
            var data = Service.GetAllData();
            return View(data);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Login(FormCollection form)
        {
            UserAccount userAccount = new UserAccount();

            string userId = form["userId"];
            string password = form["password"];

            userAccount.UserId = userId;
            userAccount.Password = password;

            var message = Service.Login(userAccount);

            ViewBag.Message = message;

            Session["Message"] = message;

            string SsssionMessage = (string)Session["Message"];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult DetailGoodsInfo(FormCollection form)
        {
            string goodsId = form["goodsId"];

            var data = Service.DetailGoodsInfo(goodsId);

            return View(data);
        }

        public ActionResult InsertCart(FormCollection form)
        {
            Cart cart = new Cart();

            string userId = form["userId"];
            string goodsId = form["goodsId"];

            cart.UserAccountId = int.Parse(userId);
            cart.GoodsId = int.Parse(goodsId);
            
            Service.InsertCart(cart);

            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            int userId = 0;
            var data = Service.Cart(userId);

            return View(data);
        }

        public ActionResult AllDelete ()
        {
            Service.AllDelete();

            return RedirectToAction("Cart");
        }

        [System.Web.Mvc.HttpPost]
        public string Delete([FromBody] Cart cart)
        {
            return Service.Delete(cart);
        }
    }
}