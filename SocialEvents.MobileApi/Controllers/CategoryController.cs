using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialEvents.ViewModel;
namespace SocialEvents.MobileApi.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryDmzServiceRef.ICategoryWCFService categoryWCFService;
        public CategoryController()
        {
            categoryWCFService = new CategoryDmzServiceRef.CategoryWCFServiceClient();
        }
        // GET: api/Category
        public IEnumerable<Category> Get()
        {
            var result = categoryWCFService.GetCategories();
            return result;
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
