using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;

namespace MVC_DGHAdmin.Controllers
{
    public class CityController : Controller
    {
        private readonly IGenericGateway<CityDTO> _addressGateway = new Facade().GetCityGateway();
        private readonly String _url = "city";
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectCity()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult SelectCity(string zipcode)
        {
            

            Session["zipcode"] = zipcode;
            return RedirectToAction("Create", "Address");
        }
    }
}