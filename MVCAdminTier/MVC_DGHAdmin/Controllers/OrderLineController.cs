using System;
using System.Net;
using System.Web.Mvc;
using BLLGateway;
using BLLGateway.DTOModels;

namespace MVC_DGHAdmin.Controllers
{
    public class OrderLineController : Controller
    {
        private readonly IGenericGateway<OrderLineDTO> _orderLineGateway = new Facade().GetOrderLineGateway();
        private readonly String _url = "orderline";

        public ActionResult Index()
        {
            return View(_orderLineGateway.GetAll(_url));
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderLineDTO = _orderLineGateway.Get(_url, (int) id);
            if (orderLineDTO != null) return View(orderLineDTO);
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OrderId,ProductId,Amount,LineTotal")] OrderLineDTO orderLineDTO)
        {
            if (!ModelState.IsValid) return View(orderLineDTO);
            _orderLineGateway.Add(orderLineDTO, _url);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderLineDTO = _orderLineGateway.Get(_url, (int) id);
            if (orderLineDTO != null) return View(orderLineDTO);
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OrderId,ProductId,Amount,LineTotal")] OrderLineDTO orderLineDTO)
        {
            if (!ModelState.IsValid) return View(orderLineDTO);
            _orderLineGateway.Update(orderLineDTO, _url);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var orderLineDTO = _orderLineGateway.Get(_url, (int) id);
            if (orderLineDTO != null) return View(orderLineDTO);
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _orderLineGateway.Delete(_url, id);
            return RedirectToAction("Index");
        }
    }
}
