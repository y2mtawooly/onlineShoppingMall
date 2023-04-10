
using OnlineShoppingMall.Models.User;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Services;
using System.Web.Mvc;


namespace OnlineShoppingMall.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;
        private LoginService Service { get { if (loginService == null) { loginService = new LoginService(); } return loginService; } }

        public ActionResult Index()
        {
            var result = Service.GetAllData();
            return View(result);
        }

        [HttpPost]
        public ActionResult UserAccount(FormCollection form)
        {
            UserAccount userAccount = new UserAccount();

            string userId = form["userId"];
            string password = form["password"];

            userAccount.UserId = userId;
            userAccount.Password = password;

            var result = Service.AddUserAccount(userAccount);

            return View("Index");
        }

        public ActionResult UserAccountInfo()
        {
            return View();
        }

        public ActionResult AddUserAccountInfo(UserInfo userInfo)
        {
            var result = Service.AddUserAccountInfo(userInfo);

            return View("UserAccount");
        }


        public ActionResult FindId()
        {
            return View();
        }

        public ActionResult FindPassword()
        {
            return View();
        }

        public ActionResult FindedId()
        {
            return View();
        }

        public ActionResult FindedPassword()
        {
            return View();
        }
    }
}