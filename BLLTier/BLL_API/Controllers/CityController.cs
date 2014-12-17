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
        /// This method returns an IEnumerable of CityDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CityDTO> GetAll()
        {
            return _facade.GetCityGateway().GetAll(_url);
        }

        /// <summary>
        /// This method returns a CityDTO, from the DAL tier, which is speficified by the id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public CityDTO Get(int id)
        {
            return _facade.GetCityGateway().Get(_url, id);
        }

        /// <summary>
        /// This method post a CityDTO, to the DAL tier.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CityDTO city)
        {
            return _facade.GetCityGateway().Add(city, _url);
        }
        /// <summary>
        /// This method put a CityDTO, to the DAL tier.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CityDTO city)
        {
            return _facade.GetCityGateway().Update(city, _url);
        }
        /// <summary>
        /// This method delete a CityDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetCityGateway().Delete(_url, id);
        }
        /// <summary>
        /// This method returns a CityDTO, by its zipcode, from the DAL tier.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
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
