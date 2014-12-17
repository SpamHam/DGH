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

        // GET: City
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectCity()
        {
            CityDTO model = new CityDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult SelectCity(string zipcode)
        {
            if (!ModelState.IsValid) return RedirectToAction("SelectCity");
            {

                Session["zipcode"] = zipcode;
                return RedirectToAction("Create", "Address");
            }

        }
    }
}