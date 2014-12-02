using BLL.DTOModels;
using BLL.Gateway;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace BLL_API.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
         private readonly Facade _facade;
        private readonly String _url = "product";
        
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
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _facade.GetProductGateway().GetAll(_url);
        }


        [HttpGet]
        [Route("{id:int}")]
        public ProductDTO Get(int id)
        {
            return _facade.GetProductGateway().Get(_url, id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductDTO product)
        {
            return _facade.GetProductGateway().Add(product, _url);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(ProductDTO product)
        {
            return _facade.GetProductGateway().Update(product, _url);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetProductGateway().Delete(_url, id);          
        }
    }
}
