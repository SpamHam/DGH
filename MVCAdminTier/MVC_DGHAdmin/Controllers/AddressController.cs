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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_addressGateway.GetAll(_addressUrl).ToList());
        }


        // GET: Address/Details/5
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

        // GET: Address/Create
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

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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


        // GET: Address/Edit/5
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



        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Address/Delete/5
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

        // POST: Address/Delete/5
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
