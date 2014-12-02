using DAL;
using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAL_API.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly Facade _facade;

        public CustomerController()
        {
            _facade = new Facade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _facade.GetCustomerRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific Customer found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCustomerById")]
        public HttpResponseMessage Get(int id)
        {
            var customer = _facade.GetCustomerRepository().Get(id);
            if (customer != null)
            {
                return Request.CreateResponse<CustomerDTO>(HttpStatusCode.OK, customer);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Customer not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Customer in the Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CustomerDTO customer)
        {
            try
            {
                _facade.GetCustomerRepository().Create(customer);

                var response = Request.CreateResponse<CustomerDTO>(HttpStatusCode.Created, customer);
                var uri = Url.Link("GetCustomerById", new { customer.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a customer to the database")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Updates a Customer in Database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CustomerDTO customer)
        {
            try
            {
                _facade.GetCustomerRepository().Update(customer);
                var response = Request.CreateResponse<CustomerDTO>(HttpStatusCode.OK, customer);
                var uri = Url.Link("GetCustomerById", new { customer.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching customer")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {

            _facade.GetCustomerRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;

        }
    }
}
