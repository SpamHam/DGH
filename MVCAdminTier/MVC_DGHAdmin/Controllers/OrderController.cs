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


        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            /**
             * ville have lavet denne metode, men forbindelsen mellem customer og user blev aldrig lavet, så blev nød til at 
             * lave det hele som admin Authorize.
             * 
             * Metoden dette kunne blive lavet, var at gøre CustomerId til string og lade login systemet bestemme ID'en til customer.
             * derfra gøre nor man laver et login skulle man i samme felter også udføre at lave sig selv som som Customer.
             * 
             * var view = _orderGateway.GetAllModels(_url + "/view").Where(x => x.CustomerId.Equals(User.Identity.GetUserId()));
             * if(User.IsInRole("Admin"))
             *{
             *   view = _orderGateway.GetAllModels(_url + "/view");
             *}
             **/
            var view = _orderGateway.GetAllModels(_url + "/view");
            return View(view);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new OrderViewModels
            {
                DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "firstName,lastName" ),
                Customer = _customerGateway.GetAll("customer")
            });
        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,OrderDate,shippedDate,Shipping")] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid) return View(orderDTO);
            _orderGateway.Add(orderDTO,_url);
            return RedirectToAction("Index");
        }

        
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(new OrderViewModels
            {
                Order = _orderGateway.Get(_url, (int)id),
                DropCustomer = new SelectList(_customerGateway.GetAll("customer").ToList(), "id", "firstName,lastName"),
                Customer = _customerGateway.GetAll("customer")
            });
        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SumPurchase,sumShipping,CustomerId,OrderDate,shippedDate,Shipping")] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid) 
                return View(orderDTO);
            _orderGateway.Update(orderDTO, _url);
            return RedirectToAction("Index");
        }

        
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        
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
