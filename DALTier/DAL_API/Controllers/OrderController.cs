using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.DTOModels;

namespace DAL_API.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
       
        private readonly Facade _facade;
        public OrderController() { 
            _facade = new Facade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderDTO> GetAll()
        {
            return _facade.GetOrderRepository().GetAll();
        }


        [HttpGet]
        [Route("{id:int}", Name = "GetOrderId")]
        public HttpResponseMessage Get(int id)
        {
            var order = _facade.GetOrderRepository().Get(id);
            if (order != null)
            {
                return Request.CreateResponse<OrderDTO>(HttpStatusCode.OK, order);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderDTO order)
        {
            try
            {
                _facade.GetOrderRepository().Create(order);

                var response = Request.CreateResponse<OrderDTO>(HttpStatusCode.Created, order);
                var uri = Url.Link("GetOrderId", new { order.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("could not add product to db")
                };
                throw new HttpResponseException(response);
            }
            }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderDTO order)
        {
            try
            {
                _facade.GetOrderRepository().Update(order);
                var response = Request.CreateResponse<OrderDTO>(HttpStatusCode.OK, order);
                var uri = Url.Link("GetOrderId", new { order.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception) 
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching product")
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
           
            _facade.GetOrderRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
