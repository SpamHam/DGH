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
    public class AddressController : ApiController
    {
         private readonly Facade _facade;
        private readonly String _url = "address";
        
        public AddressController() 
        { 
            _facade = new Facade();
        }
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<AddressDTO> GetAll()
        {

            return _facade.GetAddressGateway().GetAll(_url);
        }

        [HttpGet]
        [Route("{id:int}")]
        public AddressDTO Get(int id)
        {
            return _facade.GetAddressGateway().Get(_url, id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(AddressDTO address)
        {
            return _facade.GetAddressGateway().Add(address, _url);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(AddressDTO address)
        {
            return _facade.GetAddressGateway().Update(address, _url);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetAddressGateway().Delete(_url, id);
        }
    }
}
