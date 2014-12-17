using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using Microsoft.AspNet.Identity;
using MVC_DGHAdmin.Models;

namespace MVC_DGHAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderGateway _orderGateway = new Facade().GetOrderGateway();
        private readonly IGenericGateway<CustomerDTO> _customerGateway = new Facade().GetCustomerGateway();
        private readonly String _url = "order";

        /// <summary>
        /// Returns a Index view with Order and Orderlines tables.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var view = _orderGateway.GetAllModels(_url + "/view");
            return View(view);
        }

        /// <summary>
        /// returns a view with details on specifik Order found by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        /// <summary>
        /// Returns a view with option to Create an Order.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new OrderViewModels
            {
                DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "lastname" ),
                Customer = _customerGateway.GetAll("customer")
            });
        }

        /// <summary>
        /// Creates an Order from a Create view and returns index view.
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,OrderDate,shippedDate,Shipping")] OrderDTO Order)
        {
            if (!ModelState.IsValid) return View(new OrderViewModels{DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "lastname"),Customer = _customerGateway.GetAll("customer"),Order = Order});
            _orderGateway.Add(Order,_url);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Returns a view to Update Order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(new OrderViewModels
            {
                Order = _orderGateway.Get(_url, (int)id),
                DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "lastName"),
                Customer = _customerGateway.GetAll("customer")
            });
        }

        /// <summary>
        /// Updates Order from a view and returns index view.
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SumPurchase,sumShipping,CustomerId,OrderDate,shippedDate,Shipping")] OrderDTO Order)
        {
            if (!ModelState.IsValid) return View(new OrderViewModels { DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "lastname"), Customer = _customerGateway.GetAll("customer"), Order = Order });
            _orderGateway.Update(Order, _url);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Returns a view for Delete Order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        /// <summary>
        /// Deletes order from a view, returns index.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _orderGateway.Delete(_url, (int)id);
            return RedirectToAction("Index");
        }
    }
}
