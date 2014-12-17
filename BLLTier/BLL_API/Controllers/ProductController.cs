using BLL.DTOModels;
using BLL.Gateway;
using BLL.Logic;
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
        /// This method returns an IEnumerable of ProductDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<ProductDTO> GetAll()
        {
           
          return _facade.GetProductGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns an IEnumerable of ProductDTOes, from the DAL tier, which is active.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("active")]
        public IEnumerable<ProductDTO> GetActives()
        {
            return ProductSorter.getActiveProducts(_facade.GetProductGateway().GetAll(_url));
        }


        /// <summary>
        /// This method returns a ProductDTO, from the DAL tier, which is speficified by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public ProductDTO Get(int id)
        {
            return _facade.GetProductGateway().Get(_url, id);
        }

        /// <summary>
        /// This method post a OrderLineDTO, to the DAL tier.  
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(ProductDTO product)
        {
            return _facade.GetProductGateway().Add(product, _url);
        }

        /// <summary>
        /// This method put a ProductDTO, to the DAL tier.  
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(ProductDTO product)
        {
            return _facade.GetProductGateway().Update(product, _url);
        }

        /// <summary>
        /// This method delete a ProductDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetProductGateway().Delete(_url, id);          
        }
    }
}
