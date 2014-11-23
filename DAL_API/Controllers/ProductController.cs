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
    public class ProductController : ApiController
    {
        private Facade facade;
        private IEnumerable<ProductDTO> products;
        public ProductController() { 
            facade = new Facade();
            products = new List<ProductDTO>();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            foreach (var tempProduct in facade.GetProductRepository().GetAll())
            {
               ((List<ProductDTO>)products).Add(new ProductDTO()
                {
                    id = tempProduct.id,
                    name = tempProduct.name,
                    productNumber = tempProduct.productNumber,
                    color = tempProduct.color,
                    stock = tempProduct.stock,
                    salesPrice = tempProduct.salesPrice
                });

            }
            return products;
        }

        /// <summary>
        /// Will get a specific Genre found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {

            var product = facade.GetProductRepository().Get(id);
            if (product != null)
            {
                ProductDTO prod = new ProductDTO();
                
                prod.id = product.id;
                prod.name = product.name;
                prod.productNumber = product.productNumber;
                prod.color = product.color;
                prod.stock = product.stock;
                prod.salesPrice = product.salesPrice;
                return Request.CreateResponse<ProductDTO>(HttpStatusCode.OK, prod);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent("Product not found.");
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Creates a Genre in the Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(Product item)
        {
            try
            {
                facade.GetProductRepository().Create(item);

                var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
                string uri = Url.Link("DefaultApi", new { id = item.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception e)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Content = new StringContent("cloud not add product to db");
                throw new HttpResponseException(response);
            }
            }
        /// <summary>
        /// Updates a Genre in Database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(Product genre)
        {
            try
            {
                facade.GetProductRepository().Update(genre);
                var response = Request.CreateResponse<Product>(HttpStatusCode.OK, genre);
                string uri = Url.Link("DefaultApi", new { id = genre.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception e) 
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.Content = new StringContent("No matching product");
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Delete a Genre
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
           
            facade.GetProductRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
