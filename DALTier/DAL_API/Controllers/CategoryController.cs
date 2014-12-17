using DAL;
using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAL_API.Controllers
{
    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private readonly Facade _facade;

        private CategoryController()
        {
            _facade = new Facade();
        }

        /// <summary>
        /// Will get all Category from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _facade.GetCategoryRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Category found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        public HttpResponseMessage Get(int id)
        {
            var category = _facade.GetCategoryRepository().Get(id);
            if (category != null)
            {
                return Request.CreateResponse<CategoryDTO>(HttpStatusCode.OK, category);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Category in the Database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CategoryDTO category)
        {
            try
            {
                _facade.GetCategoryRepository().Create(category);

                var response = Request.CreateResponse<CategoryDTO>(HttpStatusCode.Created, category);
                var uri = Url.Link("GetCategoryById", new { category.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add category to db")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Updates a Category in Database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CategoryDTO category)
        {
            try
            {
                _facade.GetCategoryRepository().Update(category);
                var response = Request.CreateResponse<CategoryDTO>(HttpStatusCode.OK, category);
                var uri = Url.Link("GetProductById", new { category.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching category")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Delete a Category from database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {

            _facade.GetCategoryRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;

        }
    }
}
