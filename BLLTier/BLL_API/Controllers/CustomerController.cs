using BLL.DTOModels;
using BLL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BLL_API.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly Facade _facade;
        private readonly String _url = "customer";

        public CustomerController()
        {
            _facade = new Facade();
        }

        /// <summary>
        /// This method returns an IEnumerable of CustomerDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _facade.GetCustomerGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns a CustomerDTO, from the DAL tier, which is speficified by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public CustomerDTO Get(int id)
        {
            return _facade.GetCustomerGateway().Get(_url, id);
        }

        /// <summary>
        /// This method post a CustomerDTO, to the DAL tier. 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CustomerDTO customer)
        {
            return _facade.GetCustomerGateway().Add(customer, _url);
        }

        /// <summary>
        /// This method put a CustomerDTO, to the DAL tier.     
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CustomerDTO customer)
        {
            return _facade.GetCustomerGateway().Update(customer, _url);
        }

        /// <summary>
        /// This method delete a CustomerDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetCustomerGateway().Delete(_url, id);
        }

    }

}
