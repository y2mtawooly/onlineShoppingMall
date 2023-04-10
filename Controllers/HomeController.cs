using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Services;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace OnlineShoppingMall.Controllers
{
    public class HomeController : Controller
    {

        private HomeService homeService;
        private HomeService Service { get { if (homeService == null) { homeService = new HomeService(); } return homeService; } }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            UserAccount userAccount = new UserAccount();

            string userId = form["userId"];
            string password = form["password"];

            userAccount.UserId = userId;
            userAccount.Password = password;

            var result = Service.Login(userAccount);

            if (result == null)
            {
                ViewBag.Message = "IDまたはパスワードをもう一度確認してください。";
                return View();
            }
            else { return View("Index"); }
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
    }
}