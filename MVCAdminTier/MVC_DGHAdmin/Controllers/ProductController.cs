using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLLGateway.DTOModels;
using BLLGateway.Gateway;
using MVC_DGHAdmin.Models;

namespace MVC_DGHAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericGateway<ProductDTO> _productGateway = new Facade().GetProductGateway();
        private readonly IGenericGateway<CategoryDTO> _categoryGateway = new Facade().GetCategoryGateway();
        private readonly String _url = "product";

        /// <summary>
        /// Return Index for Product with a table of products.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ProductViewModels pvModel = new ProductViewModels();
            pvModel.products = _productGateway.GetAll(_url).ToList();
            pvModel.categories = _categoryGateway.GetAll("category").ToList();
            return View(pvModel);
        }

        public ActionResult ClientIndex()
        {
            ProductViewModels pvModel = new ProductViewModels();
            pvModel.products = _productGateway.GetAll(_url + "/active").ToList();
            pvModel.categories = _categoryGateway.GetAll("category").ToList();
            return View(pvModel);
        }

        /// <summary>
        /// Return a detail view of a specific product found by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            if (User.IsInRole("Admin"))
            {
                return View("AdminDetails", productDTO);
            }
            return View(productDTO);
        }

        /// <summary>
        /// Returns a Create view for Product.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.dropCategories = new SelectList(_categoryGateway.GetAll("category").ToList(), "id", "categoryName");
            return View();
        }

        /// <summary>
        /// Creates a Product from view, returns index view.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,productNumber,color,stock,salesPrice,categoryId,imageUrl,active")] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dropCategories = new SelectList(_categoryGateway.GetAll("category").ToList(), "id", "categoryName");
                return View(productDTO);
            }
       
            _productGateway.Add(productDTO, _url);
            return RedirectToAction("Index");
            
        }

        /// <summary>
        /// Returns a Edit view for Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
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
            ViewBag.dropCategories = new SelectList(_categoryGateway.GetAll("category").ToList(), "id", "categoryName");
            return View(productDTO);
        }

        /// <summary>
        /// Edits a Product from view, returns Index View.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Actually not in use.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Actually not in use.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDTO productDTO = _productGateway.Get(_url, (int)id);
            productDTO.active = false;
            _productGateway.Update(productDTO,_url);
            return RedirectToAction("Index");
        }
    }
}
