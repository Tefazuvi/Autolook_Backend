using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using AutoLookBackend.Models;
using System.Web.Http;

namespace AutoLookBackend.Controllers
{
    public class ReceiveController : Controller
    {

        [System.Web.Http.HttpPost]
        public string SaveCar(ReceiveModel car, int userid)
        {
            string saved = car.SaveCar(car,userid);
            return saved;
        }

        [System.Web.Http.HttpGet]
        public string GetCars()
        {
            ReceiveModel car = new ReceiveModel();
            string ans = car.GetCars();
            return ans;
        }
    }
}
