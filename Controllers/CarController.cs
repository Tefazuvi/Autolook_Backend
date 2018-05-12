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
    public class CarController : Controller
    {

        [System.Web.Http.HttpPost]
        public string SaveCar(CarModel car)
        {
            string saved = car.SaveCar(car);
            return saved;
        }

        [System.Web.Http.HttpGet]
        public string GetCars(CarModel car)
        {
            string ans = car.GetCars();
            return ans;
        }
    }
}
