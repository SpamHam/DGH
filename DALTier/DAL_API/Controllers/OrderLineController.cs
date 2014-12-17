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

        /// <summary>
        /// Will get all Orderlines from database
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<OrderLineDTO> GetAll()
        {
            return _facade.GetOrderLineRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Orderline found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetOrderLineId")]
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

        /// <summary>
        /// Creates a Orderline
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(OrderLineDTO orderLine)
        {
               _facade.GetOrderLineRepository().Create(orderLine);
                
                var response = Request.CreateResponse<OrderLineDTO>(HttpStatusCode.Created, orderLine);
                var uri = Url.Link("GetOrderLineId", new { orderLine.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

        /// <summary>
        /// Updates a Orderline
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(OrderLineDTO orderLine)
        {
            try
            {
                _facade.GetOrderLineRepository().Update(orderLine);
                var response = Request.CreateResponse<OrderLineDTO>(HttpStatusCode.OK, orderLine);
                var uri = Url.Link("GetOrderLineId", new { orderLine.id });
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

        /// <summary>
        /// Deletes a Orderline
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
