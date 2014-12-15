using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using DAL.DTOModels;

namespace DAL_API.Controllers
{
    [RoutePrefix("address")]
    public class AddressController : ApiController
    {
        private readonly Facade _facade;

        public AddressController()
        {
            _facade = new Facade(); 
        }

        // GET: api/Address
        [HttpGet]
        [Route("")]
        public IEnumerable<AddressDTO> GetAll()
        {
            return _facade.GetAddressRepository().GetAll();
        }

        // GET: api/Address/5
        [HttpGet]
        [Route("{id:int}", Name = "GetAddressId")]
        public HttpResponseMessage Get(int id)
        {
            var address = _facade.GetAddressRepository().Get(id);
            if (address != null)
            {
                return Request.CreateResponse<AddressDTO>(HttpStatusCode.OK, address);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(AddressDTO address)
        {
            try
            {
                _facade.GetAddressRepository().Create(address);

                var response = Request.CreateResponse<AddressDTO>(HttpStatusCode.Created, address);
                var uri = Url.Link("GetAddressId", new { address.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("could not add address to db")
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(AddressDTO address)
        {
            try
            {
                _facade.GetAddressRepository().Update(address);
                var response = Request.CreateResponse<AddressDTO>(HttpStatusCode.OK, address);
                var uri = Url.Link("GetAddressId", new { address.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching address")
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {

            _facade.GetAddressRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;

        }

        [HttpGet]
        [Route("getLatestAddress")]
        public HttpResponseMessage getLatestAddress()
        {

            var address = _facade.GetAddressRepository().getLatestAddress();
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