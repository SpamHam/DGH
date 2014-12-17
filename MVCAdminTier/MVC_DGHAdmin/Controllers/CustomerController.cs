using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using MVC_DGHAdmin.Models;
using BLLGateway;

namespace MVC_DGHAdmin.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IGenericGateway<CustomerDTO> _customerGateway = new Facade().GetCustomerGateway();
        private readonly ICityGateway _cityGateway = new Facade().GetCityGateway();
        private readonly IAddressGateway _addressGateway = new Facade().GetAddressGateway();
        private readonly String _url = "customer";
        private readonly String _cityUrl = "city";
        private readonly String _addressyUrl = "address";

       
        /// <summary>
        /// This method shows a index of customer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_customerGateway.GetAll(_url).ToList());
        }

        /// <summary>
        /// This method show the details of a given customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SelectedCustomer = _customerGateway.Get(_url, (int)id);

            if (model.SelectedCustomer == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        /// <summary>
        /// This method redirect to another action in an another controller.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCity()
        {
            return RedirectToAction("SelectCity", "City");
        }

        /// <summary>
        /// This method returns a view to create a customer. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            AddressCityCustomerViewModel model = new AddressCityCustomerViewModel();
            model.SelectedAddress = _addressGateway.getLatestAddress(_addressyUrl + "/getLatestAddress");
            model.SelectedCity = _cityGateway.getCityByZipcode(_cityUrl + "/getCityByZipcode", (string)Session["zipcode"]);
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
            CustomerDTO customerDTO = new CustomerDTO() { email = model.SelectedCustomer.email, invoiceAddressId = model.SelectedAddress.id, firstName = model.SelectedCustomer.firstName, lastName = model.SelectedCustomer.lastName, phone = model.SelectedCustomer.phone };
            if (!ModelState.IsValid) return View(customerDTO);
            {
                _customerGateway.Add(customerDTO, _url);

                return RedirectToAction("Index");
            }


        }

        /// <summary>
        /// This method returns a view where a given customer can edit the information. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            AddressCityCustomerViewModel model = new AddressCityCustomerViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SelectedCustomer = _customerGateway.Get(_url, (int)id);
            model.SelectedAddress = _addressGateway.Get(_addressyUrl, (int)model.SelectedCustomer.invoiceAddressId);
            model.SelectedCity = _cityGateway.Get(_cityUrl, (int)model.SelectedAddress.cityId);
            if (model.SelectedCustomer == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        /// <summary>
        /// This method get the information to edit a customer. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressCityCustomerViewModel model)
        {
            CityDTO cityDTO = _cityGateway.getCityByZipcode(_cityUrl + "/getCityByZipcode", model.SelectedCity.zipCode);
            CustomerDTO customerDTO = model.SelectedCustomer;
            AddressDTO addressDTO = new AddressDTO() { id = model.SelectedCustomer.invoiceAddressId, streetName = model.SelectedAddress.streetName, streetNumber = model.SelectedAddress.streetNumber, cityId = cityDTO.id };

            if (!ModelState.IsValid) return View(customerDTO);
            {
                _customerGateway.Update(customerDTO, _url);
                _addressGateway.Update(addressDTO, _addressyUrl);
                _cityGateway.Update(cityDTO, _cityUrl);
                return RedirectToAction("Index");
            }

        }

        /// <summary>
        /// This method returns a view where a given customer can be deleted. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SelectedCustomer = _customerGateway.Get(_url, (int)id);
            if (model.SelectedCustomer == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        /// <summary>
        /// This method get the information to delete a customer. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _customerGateway.Delete(_url, id);

            return RedirectToAction("Index");
        }


    }
}
