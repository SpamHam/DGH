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

        /// <summary>
        /// This method shows a index of cities.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This method return view to select a city by zipcode.
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCity()
        {
            CityDTO model = new CityDTO();
            return View(model);
        }
        /// <summary>
        /// This method get zipcode of a given city and redirect to an action in an another controller.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
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