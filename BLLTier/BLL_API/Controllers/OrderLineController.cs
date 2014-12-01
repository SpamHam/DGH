using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOModels;
using BLL.Gateway;

namespace BLL_API.Controllers
{
    [RoutePrefix("orderline")]
    public class OrderLineController : ApiController
    {

        private readonly Facade _facade;

        public OrderLineController()
        {
            _facade = new Facade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderLineDTO> GetAll()
        {
            return _facade.GetOrderLineGateway().GetAll("orderline");
        }


        [HttpGet]
        [Route("{id:int}")]
        public OrderLineDTO Get(int id)
        {
            return _facade.GetOrderLineGateway().Get("orderline", id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderLineDTO orderLine)
        {
            return _facade.GetOrderLineGateway().Add(orderLine, "orderline");
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderLineDTO orderLine)
        {
            return _facade.GetOrderLineGateway().Update(orderLine, "orderline");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetOrderLineGateway().Delete("orderline", id);
        }
    }
}
