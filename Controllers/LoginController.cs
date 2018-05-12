using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using AutoLookBackend.Models;
using System.Web.Mvc;

namespace AutoLookBackend.Controllers
{
    public class LoginController : Controller
    {

        [System.Web.Http.HttpPost]
        public string Authenticate(string User, string Pass)
        {
            LoginModel login = new LoginModel();
            string user = login.Login(User, Pass);
            return user;
        }

        [System.Web.Http.HttpPost]
        public string SaveUser(LoginModel user)
        {
            string saved = user.SaveUser(user);
            return saved;
        }

        [System.Web.Http.HttpPost]
        public string DeleteUser(LoginModel user)
        {
            string deleted = user.DeleteUser(user);
            return deleted;
        }

        [System.Web.Http.HttpPost]
        public string UpdateUser(LoginModel user)
        {
            string updated = user.UpdateUser(user);
            return updated;
        }

        [System.Web.Http.HttpPost]
        public string SaveFavorite(int idVehicles, int idUser)
        {
            LoginModel login = new LoginModel();
            string saved = login.SaveFavorite(idVehicles, idUser);
            return saved;
        }

        [System.Web.Http.HttpGet]
        public string GetFavorite(int idUser)
        {
            LoginModel login = new LoginModel();
            string ans = login.GetFavorite(idUser);
            return ans;
        }
    }
}
