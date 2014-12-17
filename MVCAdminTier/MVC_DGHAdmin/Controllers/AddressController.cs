using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using MVC_DGHAdmin.Models;
using BLLGateway;
using BLLGateway.Gateway;


namespace MVC_DGHAdmin.Controllers
{
    public class AddressController : Controller
    {
        private readonly IGenericGateway<AddressDTO> _addressGateway = new Facade().GetAddressGateway();
        private readonly ICityGateway _cityGateway = new Facade().GetCityGateway();
        private readonly String _addressUrl = "address";
        private readonly String _cityUrl = "city";


        /// <summary>
        /// This method shows a index of addresses.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_addressGateway.GetAll(_addressUrl).ToList());
        }


        /// <summary>
        /// This method show the details of a given address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressDTO addressDTO = _addressGateway.Get(_addressUrl, (int)id);
            if (addressDTO == null)
            {
                return HttpNotFound();
            }
            return View(addressDTO);
        }

        /// <summary>
        /// This method returns a view to create a address. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            string b = (string)Session["zipcode"];
            AddressCityCustomerViewModel model = new AddressCityCustomerViewModel();
            model.SelectedCity = new CityDTO() { zipCode = (string)Session["zipcode"] };
            var city = _cityGateway.getCityByZipcode(_cityUrl + "/getCityByZipcode", (string)Session["zipcode"]);
            model.SelectedCity.City = city.City;
            model.SelectedCity.id = city.id;

            return View(model);

        }

        /// <summary>
        /// This method get the information to create a customer. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressCityCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddressDTO addressDTO = new AddressDTO() { streetName = model.SelectedAddress.streetName, streetNumber = model.SelectedAddress.streetNumber, cityId = model.SelectedCity.id };
                Session["Address"] = addressDTO;


                _addressGateway.Add(addressDTO, _addressUrl);
                return RedirectToAction("Create", "Customer");
            }

            return View(model);
        }


        /// <summary>
        /// This method returns a view where a given address can be edited. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressDTO addressDTO = _addressGateway.Get(_addressUrl, (int)id);
            if (addressDTO == null)
            {
                return HttpNotFound();
            }
            return View(addressDTO);
        }



        /// <summary>
        /// This method get the information to edit a address.
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,streetName,streetNumber,cityId")] AddressDTO addressDTO)
        {
            if (ModelState.IsValid)
            {
                _addressGateway.Update(addressDTO, _addressUrl);
                return RedirectToAction("Index");
            }
            return View(addressDTO);
        }

        /// <summary>
        /// This method returns a view where a given address can be deleted. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressDTO addressDTO = _addressGateway.Get(_addressUrl, (int)id);
            if (addressDTO == null)
            {
                return HttpNotFound();
            }
            return View(addressDTO);
        }

        /// <summary>
        /// This method get the information to delete a address. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressDTO addressDTO = _addressGateway.Get(_addressUrl, (int)id);
            _addressGateway.Delete(_addressUrl, id);

            return RedirectToAction("Index");
        }


    }
}
