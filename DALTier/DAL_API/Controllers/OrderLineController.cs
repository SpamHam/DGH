using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.DTOModels;

namespace DAL_API.Controllers
{
    [RoutePrefix("orderline")]
    public class OrderLineController : ApiController
    {
       
        private readonly Facade _facade;
        public OrderLineController() { 
            _facade = new Facade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<OrderLineDTO> GetAll()
        {
            return _facade.GetOrderLineRepository().GetAll();
        }


        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var orderLine = _facade.GetOrderLineRepository().Get(id);
            if (orderLine != null)
            {
                return Request.CreateResponse<OrderLineDTO>(HttpStatusCode.OK, orderLine);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderLineDTO orderLine)
        {
            try
            {
                _facade.GetOrderLineRepository().Create(orderLine);

                var response = Request.CreateResponse<OrderLineDTO>(HttpStatusCode.Created, orderLine);
                var uri = Url.Link("DefaultApi", new {orderLine.id });
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
        public HttpResponseMessage Put(OrderLineDTO orderLine)
        {
            try
            {
                _facade.GetOrderLineRepository().Update(orderLine);
                var response = Request.CreateResponse<OrderLineDTO>(HttpStatusCode.OK, orderLine);
                var uri = Url.Link("DefaultApi", new {orderLine.id });
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
           
            _facade.GetOrderLineRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
