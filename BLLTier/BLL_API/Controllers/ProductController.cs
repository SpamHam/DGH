using BLL.DTOModels;
using BLL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BLL_API.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
         private readonly Facade _facade;
        
        public ProductController() 
        { 
            _facade = new Facade();
        }
        /// <summary>
        /// Hejejejjj
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ProductDTO> GetAll()
        {
            return _facade.GetProductGateway().GetAll("product");
        }


        [HttpGet]
        [Route("{id:int}")]
        public ProductDTO Get(int id)
        {
            return _facade.GetProductGateway().Get("product/" + id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductDTO product)
        {    
            return _facade.GetProductGateway().Add(product, "product");
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(ProductDTO product)
        {
            return _facade.GetProductGateway().Update(product, "product");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
         return _facade.GetProductGateway().Delete("product/" + id);          
        }
    }
}
