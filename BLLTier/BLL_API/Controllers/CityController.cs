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
    [RoutePrefix("city")]
    public class CityController : ApiController
    {
        private readonly Facade _facade;
        private readonly String _url = "city";

        public CityController()
        {
            _facade = new Facade();
        }

        /// <summary>
        /// Hejejejjj
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CityDTO> GetAll()
        {
            return _facade.GetCityGateway().GetAll(_url);
        }


        [HttpGet]
        [Route("{id:int}")]
        public CityDTO Get(int id)
        {
            return _facade.GetCityGateway().Get(_url, id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CityDTO city)
        {
            return _facade.GetCityGateway().Add(city, _url);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CityDTO city)
        {
            return _facade.GetCityGateway().Update(city, _url);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetCityGateway().Delete(_url, id);
        }

        [HttpGet]
        [Route("getCityByZipcode/{zipcode}")]
        public HttpResponseMessage getCityByZipcode(string zipcode)
        {

            var city = _facade.GetCityGateway().getCityByZipcode(_url + "/getCityByZipcode", zipcode);
            if (city != null)
            {
                return Request.CreateResponse<CityDTO>(HttpStatusCode.OK, city);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("City not found.")
            };
            throw new HttpResponseException(response);
        }
    }
}
