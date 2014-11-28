using DAL;
using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAL_API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly Facade _facade;
        public ProductController() { 
            _facade = new Facade();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _facade.GetProductRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Genre found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Creates a Genre in the Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(ProductDTO product)
        {
            try
            {
                _facade.GetProductRepository().Create(product);

                var response = Request.CreateResponse<ProductDTO>(HttpStatusCode.Created, product);
                var uri = Url.Link("DefaultApi", new {product.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception e)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("cloud not add product to db")
                };
                throw new HttpResponseException(response);
            }
            }
        /// <summary>
        /// Updates a Genre in Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(ProductDTO product)
        {
            try
            {
                _facade.GetProductRepository().Update(product);
                var response = Request.CreateResponse<ProductDTO>(HttpStatusCode.OK, product);
                var uri = Url.Link("DefaultApi", new {product.id });
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
        /// Delete a Genre
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
           
            _facade.GetProductRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
