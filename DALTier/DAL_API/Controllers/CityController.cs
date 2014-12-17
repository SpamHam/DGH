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
    [RoutePrefix("city")]
    public class CityController : ApiController
    {
        private readonly Facade _facade;
        public CityController()
        {
            _facade = new Facade();
        }

        /// <summary>
        /// Will get all City from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CityDTO> GetAll()
        {
            return _facade.GetCityRepository().GetAll();
        }

        /// <summary>
        /// Will get a specific City found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCityById")]
        public HttpResponseMessage Get(int id)
        {
            var city = _facade.GetCityRepository().Get(id);
            if (city != null)
            {
                return Request.CreateResponse<CityDTO>(HttpStatusCode.OK, city);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Product not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a City in the Database.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CityDTO city)
        {
            try
            {
                _facade.GetCityRepository().Create(city);

                var response = Request.CreateResponse<CityDTO>(HttpStatusCode.Created, city);
                var uri = Url.Link("GetCityById", new { city.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add city to the database")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Updates a City in Database
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CityDTO city)
        {
            try
            {
                _facade.GetCityRepository().Update(city);
                var response = Request.CreateResponse<CityDTO>(HttpStatusCode.OK, city);
                var uri = Url.Link("GetCityById", new { city.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching City")
                };
                throw new HttpResponseException(response);
            }
        }
        /// <summary>
        /// Delete a City in database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {

            _facade.GetCityRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;

        }

        /// <summary>
        /// will get a specifik city found by zipcode.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("getCityByZipcode/{zipcode}")]
        public HttpResponseMessage GetCityByZipcode(string zipcode)
        {
           
            var city = _facade.GetCityRepository().getCityByZipcode(zipcode);
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
