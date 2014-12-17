using DAL;
using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAL_API.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private readonly Facade _facade;
        public ProductController() { 
            _facade = new Facade();
        }

        /// <summary>
        /// Will get all Product in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ProductDTO> GetAll()
        {
            return _facade.GetProductRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Product found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetProductById")]
        public HttpResponseMessage Get(int id)
        {
            var product = _facade.GetProductRepository().Get(id);
            if (product != null)
            {
                return Request.CreateResponse<ProductDTO>(HttpStatusCode.OK, product);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Product in the Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductDTO product)
        {
            try
            {
                _facade.GetProductRepository().Create(product);

                var response = Request.CreateResponse<ProductDTO>(HttpStatusCode.Created, product);
                var uri = Url.Link("GetProductById", new { product.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add product to the database")
                };
                throw new HttpResponseException(response);
            }
            }

        /// <summary>
        /// Updates a Product in Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(ProductDTO product)
        {
            try
            {
                _facade.GetProductRepository().Update(product);
                var response = Request.CreateResponse<ProductDTO>(HttpStatusCode.OK, product);
                var uri = Url.Link("GetProductById", new { product.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception) 
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching product")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Delete a Product in database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
           
            _facade.GetProductRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
