using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOModels;
using BLL.Gateway;

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

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderDTO> GetAll()
        {
            return _facade.GetOrderGateway().GetAll(_url);
        }


        [HttpGet]
        [Route("{id:int}")]
        public OrderDTO Get(int id)
        {
            return _facade.GetOrderGateway().Get(_url, id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderDTO order)
        {
            return _facade.GetOrderGateway().Add(order, _url);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderDTO order)
        {
            return _facade.GetOrderGateway().Update(order, _url);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetOrderGateway().Delete(_url, id);          
        }

        [HttpGet]
        [Route("view")]
        public IEnumerable<OrderModelDTO> getAllModels()
        {
            return _facade.GetOrderGateway().GetAllModels(_url + "/view");
        } 
    }
}
