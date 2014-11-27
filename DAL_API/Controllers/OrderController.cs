using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.DTOModels;

namespace DAL_API.Controllers
{
    public class OrderController : ApiController
    {
       
        private readonly Facade _facade;
        public OrderController() { 
            _facade = new Facade();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _facade.GetOrderRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Order found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            var product = _facade.GetOrderRepository().Get(id);
            if (product != null)
            {
                return Request.CreateResponse<OrderDTO>(HttpStatusCode.OK, product);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Order in the Database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(OrderDTO order)
        {
            try
            {
                _facade.GetOrderRepository().Create(order);

                var response = Request.CreateResponse<OrderDTO>(HttpStatusCode.Created, order);
                var uri = Url.Link("DefaultApi", new {order.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception e)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("cloud not add product to db")
                };
                throw new HttpResponseException(response);
            }
            }
        /// <summary>
        /// Updates a Order in Database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(OrderDTO order)
        {
            try
            {
                _facade.GetOrderRepository().Update(order);
                var response = Request.CreateResponse<OrderDTO>(HttpStatusCode.OK, order);
                var uri = Url.Link("DefaultApi", new {order.id });
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
        /// Delete a Order
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
           
            _facade.GetOrderRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
           
        }
    }
}
