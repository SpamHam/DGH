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
    [RoutePrefix("address")]
    public class AddressController : ApiController
    {
        private readonly Facade _facade;
        private readonly String _url = "address";

        public AddressController()
        {
            _facade = new Facade();
        }
        /// <summary>
        /// This method returns an IEnumerable of addressDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<AddressDTO> GetAll()
        {

            return _facade.GetAddressGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns an addressDTO, from the DAL tier, which is speficified by the id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public AddressDTO Get(int id)
        {
            return _facade.GetAddressGateway().Get(_url, id);
        }
        /// <summary>
        /// This method post an AddressDTO, to the DAL tier. 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(AddressDTO address)
        {
            return _facade.GetAddressGateway().Add(address, _url);
        }
        /// <summary>
        /// This method put an AddressDTO, to the DAL tier.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(AddressDTO address)
        {
            return _facade.GetAddressGateway().Update(address, _url);
        }
        /// <summary>
        /// This method delete an AddressDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetAddressGateway().Delete(_url, id);
        }

        /// <summary>
        /// This method returns the latest created ADDressDTO, from the DAL tier. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getLatestAddress")]
        public HttpResponseMessage getLatestAddress()
        {

            var address = _facade.GetAddressGateway().getLatestAddress(_url + "/getLatestAddress");
            if (address != null)
            {
                return Request.CreateResponse<AddressDTO>(HttpStatusCode.OK, address);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("address not found.")
            };
            throw new HttpResponseException(response);
        }
    }
}
