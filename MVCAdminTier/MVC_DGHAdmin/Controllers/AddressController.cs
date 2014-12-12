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

        // GET: Address
        public ActionResult Index()
        {
            return View(_addressGateway.GetAll(_addressUrl).ToList());
        }

        // GET: Address/Details/5
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

        // GET: Address/Create
        public ActionResult Create()
        {
            string b = (string)Session["zipcode"];
            AddressCityCustomerViewModel model = new AddressCityCustomerViewModel();
            model.SelectedCity = new CityDTO() { zipCode = (string)Session["zipcode"]}; 
            var city = _cityGateway.getCityByZipcode(_cityUrl + "/getCityByZipcode", (string)Session["zipcode"]);
            model.SelectedCity.City = city.City;
            model.SelectedCity.id = city.id;

            return View(model);
            //return RedirectToAction("Create", "Customer", model);
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressCityCustomerViewModel model)//[Bind(Include = "id,streetName,streetNumber,cityId")] AddressDTO addressDTO)
        {
            if (ModelState.IsValid)
            {
                AddressDTO addressDTO = new AddressDTO() { streetName = model.SelectedAddress.streetName, streetNumber = model.SelectedAddress.streetNumber, cityId = model.SelectedCity.id };
                string s = model.SelectedCity.City;
                _addressGateway.Add(addressDTO, _addressUrl);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Address/Edit/5
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

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Address/Delete/5
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

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressDTO addressDTO = _addressGateway.Get(_addressUrl, (int) id);
            _addressGateway.Delete(_addressUrl , id);
            
            return RedirectToAction("Index");
        }

       
    }
}
