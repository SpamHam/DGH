using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using BLL.DTOModels;
using BLL.Gateway;

namespace BLL_API.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
       
        private readonly Facade _facade;
        
        public OrderController() 
        { 
            _facade = new Facade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderDTO> GetAll()
        {
            return _facade.GetOrderGateway().GetAll("order");
        }


        [HttpGet]
        [Route("{id:int}")]
        public OrderDTO Get(int id)
        {
            return _facade.GetOrderGateway().Get("order/" + id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderDTO order)
        {    
            return _facade.GetOrderGateway().Add(order, "order");
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderDTO order)
        {
            return _facade.GetOrderGateway().Update(order, "order");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
         return _facade.GetOrderGateway().Delete("order/" + id);          
        }
    }
}
