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

        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _facade.GetCategoryGateway().GetAll("category");
        }

        [HttpGet]
        [Route("{id:int}")]
        public CategoryDTO Get(int id)
        {
            return _facade.GetCategoryGateway().Get("category", id);

        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CategoryDTO category)
        {
            return _facade.GetCategoryGateway().Add(category, "category");
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(CategoryDTO category)
        {
            return _facade.GetCategoryGateway().Update(category, "category");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            return _facade.GetCategoryGateway().Delete("category", id);
        }
    }
}
