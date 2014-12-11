using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using BLLGateway.Gateway.Gateways;
using MVC_DGHAdmin.Models;

namespace MVC_DGHAdmin.Controllers
{
    public class OrderLineController : Controller
    {
        private readonly IGenericGateway<OrderLineDTO> _orderLineGateway = new Facade().GetOrderLineGateway();
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway(); 
        private readonly String _url = "orderline";

        public ActionResult Create(int? orderId)
        {
            if (orderId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(new OrderLineViewModels
            {
                DropProduct = new SelectList(_productGateway.GetAll("product").ToList(), "id", "name"),
                OrderLine = new OrderLineDTO {OrderId = (int) orderId},
                Product = _productGateway.GetAll("product")
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OrderId,ProductId,Amount")] OrderLineDTO orderLineDTO)
        {

            if (!ModelState.IsValid) return View(orderLineDTO);
            _orderLineGateway.Add(orderLineDTO, _url);
            return RedirectToAction("Index", "OrderController");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(new OrderLineViewModels
            {
                DropProduct = new SelectList(_productGateway.GetAll("product").ToList(), "id", "name"),
                OrderLine = _orderLineGateway.Get(_url, (int) id),
                Product = _productGateway.GetAll("product")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OrderId,ProductId,Amount")] OrderLineDTO orderLineDTO)
        {
            if (!ModelState.IsValid) return View(orderLineDTO);
            _orderLineGateway.Update(orderLineDTO, _url);
            return RedirectToAction("Index", "OrderController");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            _orderLineGateway.Delete(_url, (int)id);
            return RedirectToAction("Index", "OrderController");
        }
    }
}
