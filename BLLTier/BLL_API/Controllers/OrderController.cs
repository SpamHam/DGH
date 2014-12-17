using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOModels;
using BLL.Gateway;
using BLL.Logic;

namespace BLL_API.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
       
        private readonly Facade _facade;
        private readonly String _url = "order";
        
        public OrderController() 
        { 
            _facade = new Facade();
        }

        /// <summary>
        /// This method returns an IEnumerable of OrderDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<OrderDTO> GetAll()
        {
            return _facade.GetOrderGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns a OrderDTO, from the DAL tier, which is speficified by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public OrderDTO Get(int id)
        {
            return _facade.GetOrderGateway().Get(_url, id);
        }

        /// <summary>
        /// This method post a OrderDTO, to the DAL tier.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderDTO order)
        {
            return _facade.GetOrderGateway().Add(order, _url);
        }

        /// <summary>
        /// This method put a OrderDTO, to the DAL tier.  
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderDTO order)
        {
            return _facade.GetOrderGateway().Update(OrderSummarizer.OrderSum(
                order,
                _facade.GetOrderLineGateway().GetAll("orderline"),
                _facade.GetProductGateway().GetAll("product")), _url);
        }

        /// <summary>
        /// This method delete a OrderDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetOrderGateway().Delete(_url, id);          
        }

        [HttpGet]
        [Route("view")]
        public IEnumerable<OrderModelDTO> GetAllModels()
        {
            return _facade.GetOrderGateway().GetAllModels(_url + "/view");
        }

    }
}
