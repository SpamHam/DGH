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
    public class CategoryController : Controller
    {
        private readonly IGenericGateway<CategoryDTO> _categoryGateway = new Facade().GetCategoryGateway();
        private readonly String _url = "category";
        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryGateway.GetAll(_url).ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryDTO categoryDTO = _categoryGateway.Get(_url,(int)id);
            if (categoryDTO == null)
            {
                return HttpNotFound();
            }
            return View(categoryDTO);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,categoryName")] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return View(categoryDTO);
            {
                _categoryGateway.Add(categoryDTO, _url);
                 return RedirectToAction("Index");
            }

            
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryDTO categoryDTO = _categoryGateway.Get(_url, (int)id);
            if (categoryDTO == null)
            {
                return HttpNotFound();
            }
            return View(categoryDTO);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,categoryName")] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return View(categoryDTO);
            {
                _categoryGateway.Update(categoryDTO,_url);
                return RedirectToAction("Index");
            }
            
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryDTO categoryDTO = _categoryGateway.Get(_url, (int)id);
            if (categoryDTO == null)
            {
                return HttpNotFound();
            }
            return View(categoryDTO);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryDTO categoryDTO = _categoryGateway.Get(_url, (int)id);
            _categoryGateway.Delete(_url, id);
            return RedirectToAction("Index");
        }

       
    }
}
