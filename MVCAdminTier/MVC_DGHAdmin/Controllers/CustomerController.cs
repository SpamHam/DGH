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

namespace MVC_DGHAdmin.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IGenericGateway<CustomerDTO> _customerGateway = new Facade().GetCustomerGateway();
        private readonly String _url = "customer";
        // GET: Customer
        public ActionResult Index()
        {
            return View(_customerGateway.GetAll(_url).ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SelectedCustomer = _customerGateway.Get(_url, (int)id);
            
            if (model.SelectedCustomer== null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,phone,deliveryAddressId,invoiceAddressId,email,firstName,lastName")] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return View(customerDTO);
            {
                _customerGateway.Add(customerDTO, _url);
                
                return RedirectToAction("Index");
            }

            
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,phone,deliveryAddressId,invoiceAddressId,email,firstName,lastName")] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return View(customerDTO);
            {
                _customerGateway.Update(customerDTO, _url);
                
                return RedirectToAction("Index");
            }
            
        }

        // GET: Customer/Delete/5
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

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _customerGateway.Delete(_url, id);
           
            return RedirectToAction("Index");
        }

       
    }
}
