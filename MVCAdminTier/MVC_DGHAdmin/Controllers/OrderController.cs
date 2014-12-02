using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway;
using BLLGateway.DTOModels;
using MVC_DGHAdmin.Models;
using WebGrease.Css.Extensions;

namespace MVC_DGHAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericGateway<OrderDTO> _orderGateway = new Facade().GetOrderGateway();
        private readonly IGenericGateway<OrderLineDTO> _orderLineGateway = new Facade().GetOrderLineGateway();
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway();
        private readonly IGenericGateway<CustomerDTO> _customerGateway = new Facade().GetCustomerGateway();

        private readonly String _url = "order";

        public ActionResult Index()
        {
            return View(new OrderModel
            {
                order = _orderGateway.GetAll("order"),
                orderLine = _orderLineGateway.GetAll("orderline"),
                product = _productGateway.GetAll("product"),
                customer = _customerGateway.GetAll("customer")
            });
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CustomerId,OrderDate,shippedDate,SumPurchase,Shipping,sumShipping")] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid) return View(orderDTO);
            _orderGateway.Add(orderDTO,_url);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CustomerId,OrderDate,shippedDate,SumPurchase,Shipping,sumShipping")] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid) return View(orderDTO);
            _orderGateway.Update(orderDTO, _url);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderDTO = _orderGateway.Get(_url, (int)id);
            if (orderDTO != null) return View(orderDTO);
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _orderGateway.Delete(_url, (int)id);
            return RedirectToAction("Index");
        }
    }
}
