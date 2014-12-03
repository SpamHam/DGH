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
    public class ProductController : Controller
    {
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway();
        private readonly String _url = "product";

        // GET: Product
        public ActionResult Index()
        {
            return View(_productGateway.GetAll(_url).ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDTO productDTO = _productGateway.Get(_url, (int)id);
            if (productDTO == null)
            {
                return HttpNotFound();
            }
            return View(productDTO);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,productNumber,color,stock,salesPrice,categoryId,imageUrl,active")] ProductDTO productDTO)
        {
            if (!ModelState.IsValid) return View(productDTO);
            {
                _productGateway.Add(productDTO, _url);
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDTO productDTO = _productGateway.Get(_url, (int)id);
            if (productDTO == null)
            {
                return HttpNotFound();
            }
            return View(productDTO);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,productNumber,color,stock,salesPrice,categoryId,imageUrl,active")] ProductDTO productDTO)
        {
            if (!ModelState.IsValid) return View(productDTO);
            {
                _productGateway.Update(productDTO, _url);
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDTO productDTO = _productGateway.Get(_url, (int)id);
            if (productDTO == null)
            {
                return HttpNotFound();
            }
            return View(productDTO);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDTO productDTO = _productGateway.Get(_url, (int)id);
            _productGateway.Delete(_url, id);
            return RedirectToAction("Index");
        }
    }
}
