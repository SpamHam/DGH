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

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderLineDTO> GetAll()
        {
            return _facade.GetOrderLineGateway().GetAll(_url);
        }


        [HttpGet]
        [Route("{id:int}")]
        public OrderLineDTO Get(int id)
        {
            return _facade.GetOrderLineGateway().Get(_url, id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderLineDTO orderLine)
        {
            _facade.GetOrderGateway().Update(OrderSummarizer.OrderSum(
                _facade.GetOrderGateway().Get("order", orderLine.OrderId),
                _facade.GetOrderLineGateway().GetAll(_url), 
                _facade.GetProductGateway().GetAll("product")), "order");
            return _facade.GetOrderLineGateway().Add(OrderSummarizer.OrderlineSum(orderLine, _facade.GetProductGateway().GetAll("product")), _url);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderLineDTO orderLine)
        {
            return _facade.GetOrderLineGateway().Update(orderLine, _url);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetOrderLineGateway().Delete(_url, id);
        }
    }
}
