
using OnlineShoppingMall.Models.User;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Services;
using System;
using System.Web.Mvc;
using System.Web.Services.Description;


namespace OnlineShoppingMall.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;
        private LoginService Service { get { if (loginService == null) { loginService = new LoginService(); } return loginService; } }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAccount(FormCollection form)
        {
            UserAccount userAccount = new UserAccount();

            string userId = form["userId"];
            string password = form["password"];

            userAccount.UserId = userId;
            userAccount.Password = password;

            Service.AddUserAccount(userAccount);

            return View("Index");
        }

        [HttpPost]
        public ActionResult UserAccountInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserAccountInfo(UserInfo userInfo)
        {
            var result = Service.AddUserAccountInfo(userInfo);

            return View("UserAccount");
        }

        
        public ActionResult FindId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindedId(FormCollection form)
        {
            UserInfo userInfo = new UserInfo();

            var name = form["name"];
            var birth = DateTime.Parse(form["birth"]);

            userInfo.Name = name;
            userInfo.Birth = birth;

            var message = Service.FindID(userInfo);

            ViewBag.Message = message;

            return View();
        }

        public ActionResult FindPassword()
        {
            return View();
        }


        public ActionResult FindedPassword(FormCollection form)
        {
            var id = form["userId"];

            var message = Service.FindPassword(id);

            ViewBag.Message = message;

            return View();
        }
    }
}