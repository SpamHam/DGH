using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using MVC_DGHAdmin.Models;

namespace MVC_DGHAdmin.Controllers
{
    public class OrderLineController : Controller
    {
        private readonly IGenericGateway<OrderLineDTO> _orderLineGateway = new Facade().GetOrderLineGateway();
        private readonly IOrderGateway _orderGateway = new Facade().GetOrderGateway();
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway(); 
        private readonly String _url = "orderline";


        [Authorize(Roles = "Admin")]
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

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderLineViewModels = new OrderLineViewModels()
            {
                OrderLine = _orderLineGateway.Get(_url, (int) id),
                Product = _productGateway.GetAll("product")
            };
            return View(orderLineViewModels);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ProductId,Amount")]OrderLineDTO orderline)
        {
            if (!ModelState.IsValid) return View(new OrderLineViewModels(){DropProduct = new SelectList(_productGateway.GetAll("product").ToList(), "id", "name"),OrderLine = orderline,Product = _productGateway.GetAll("product")});
            _orderLineGateway.Add(orderline, _url);
            _orderGateway.Update(_orderGateway.Get("order", orderline.OrderId), "order");
            return RedirectToAction("Index", "Order/Index");
        }


        [Authorize(Roles = "Admin")]
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


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderLineDTO orderline)
        {
            if (!ModelState.IsValid) return View(orderline);
            _orderLineGateway.Update(orderline, _url);
            _orderGateway.Update(_orderGateway.Get("order", orderline.OrderId), "order");
            return RedirectToAction("Index", "Order/index");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            _orderLineGateway.Delete(_url, (int)id);
            _orderGateway.Update(_orderGateway.Get("order", _orderLineGateway.Get(_url,(int)id).OrderId), "order");
            return RedirectToAction("Index", "Order/Index");
        }
    }
}
