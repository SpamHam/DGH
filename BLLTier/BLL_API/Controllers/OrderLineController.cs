using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOModels;
using BLL.Gateway;
using BLL.Logic;

namespace BLL_API.Controllers
{
    [RoutePrefix("orderline")]
    public class OrderLineController : ApiController
    {

        private readonly Facade _facade;
        private readonly string _url = "orderline";
        public OrderLineController()
        {
            _facade = new Facade();
        }

        /// <summary>
        /// This method returns an IEnumerable of OrderLineDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<OrderLineDTO> GetAll()
        {
            return _facade.GetOrderLineGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns a OrderLineDTO, from the DAL tier, which is speficified by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public OrderLineDTO Get(int id)
        {
            return _facade.GetOrderLineGateway().Get(_url, id);
        }
        /// <summary>
        /// This method post a OrderLineDTO, to the DAL tier.
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderLineDTO orderLine)
        {
            return _facade.GetOrderLineGateway().Add(OrderSummarizer.OrderlineSum(orderLine, _facade.GetProductGateway().GetAll("product")), _url);
        }

        /// <summary>
        /// This method put a OrderLineDTO, to the DAL tier.  
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderLineDTO orderLine)
        {
            var Orderline = OrderSummarizer.OrderlineSum(orderLine, _facade.GetProductGateway().GetAll("product"));
            return _facade.GetOrderLineGateway().Update(Orderline, _url);
        }

        /// <summary>
        /// This method delete a OrderLineDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetOrderLineGateway().Delete(_url, id);
        }
    }
}
