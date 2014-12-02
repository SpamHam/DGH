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
     /// Hejejejjj
     /// </summary>
     /// <returns></returns>
     [HttpGet]
     [Route("")]
     public IEnumerable<CustomerDTO> GetAll()
     {
         return _facade.GetCustomerGateway().GetAll(_url);
     }


     [HttpGet]
     [Route("{id:int}")]
     public CustomerDTO Get(int id)
     {
         return _facade.GetCustomerGateway().Get(_url, id);
     }

     [HttpPost]
     [Route("")]
     public HttpResponseMessage Post(CustomerDTO customer)
     {
         return _facade.GetCustomerGateway().Add(customer, _url);
     }

     [HttpPut]
     [Route("")]
     public HttpResponseMessage Put(CustomerDTO customer)
     {
         return _facade.GetCustomerGateway().Update(customer, _url);
     }

     [HttpDelete]
     [Route("{id:int}")]
     public HttpResponseMessage Delete(int id)
     {
         return _facade.GetCustomerGateway().Delete(_url, id);
     }

    }

}
