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
    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private readonly Facade _facade;

        private CategoryController()
        {
            _facade = new Facade();
        }
        /// <summary>
        /// This method returns a IEnumerable of CategoryDTOes from the DAL tier.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _facade.GetCategoryGateway().GetAll("category");
        }
        /// <summary>
        /// This method returns a CategoryDTO, from the DAL tier, which is speficified by the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public CategoryDTO Get(int id)
        {
            return _facade.GetCategoryGateway().Get("category", id);

        }
        /// <summary>
        /// This method post a CategoryDTO, to the DAL tier. 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CategoryDTO category)
        {
            return _facade.GetCategoryGateway().Add(category, "category");
        }
        /// <summary>
        /// This method put a CategoryDTO, to the DAL tier.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CategoryDTO category)
        {
            return _facade.GetCategoryGateway().Update(category, "category");
        }
        /// <summary>
        /// This method delete a CategoryDTO, to The DAL tier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetCategoryGateway().Delete("category", id);
        }
    }
}
