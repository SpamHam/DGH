using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway;
using BLLGateway.DTOModels;
using DAL;
using MVC_DGHAdmin.Models.Orders;
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
            var orderDTO = _orderGateway.GetAll("order");
            var orderLineDTO = _orderLineGateway.GetAll("orderline");

            var model = new List<OModel>();
            var OrderLineModel = new List<OrderLineModel>();
            for (var oCount = 0; oCount <= orderDTO.Count(); oCount++)
            {
                {
                    model.Add(new OModel
                    {
                        Order = new OrderModel()
                        {
                            id = orderDTO.ElementAt(oCount).id,
                            CustomerName =
                                _customerGateway.Get("customer", orderDTO.ElementAt(oCount).CustomerId)
                                    .firstName + " " +
                                _customerGateway.Get("customer", orderDTO.ElementAt(oCount).CustomerId)
                                    .lastName,
                            SumPurchase = orderDTO.ElementAt(oCount).SumPurchase,
                            Shipping = orderDTO.ElementAt(oCount).Shipping,
                            sumShipping = orderDTO.ElementAt(oCount).sumShipping,
                            OrderDate = orderDTO.ElementAt(oCount).OrderDate,
                            shippedDate = orderDTO.ElementAt(oCount).shippedDate
                        }
                    });
                    OrderLineModel = new List<OrderLineModel>();
                    for (var olCount = 0; olCount <= orderLineDTO.Count(); olCount++)
                        if (orderLineDTO.ElementAt(olCount).OrderId == orderDTO.ElementAt(oCount).id)
                            OrderLineModel.Add(new OrderLineModel()
                            {
                                id = orderLineDTO.ElementAt(olCount).id,
                                Amount = orderLineDTO.ElementAt(olCount).Amount,
                                LineTotal = orderLineDTO.ElementAt(olCount).LineTotal,
                                ProductName =
                                    _productGateway.Get("product", orderLineDTO.ElementAt(olCount).ProductId).name,
                                ProductPicture =
                                    _productGateway.Get("product", orderLineDTO.ElementAt(olCount).ProductId).imageUrl,
                                ProductPrice =
                                    _productGateway.Get("product", orderLineDTO.ElementAt(olCount).ProductId).salesPrice,
                            });
                }
            }
                return View(model);
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
