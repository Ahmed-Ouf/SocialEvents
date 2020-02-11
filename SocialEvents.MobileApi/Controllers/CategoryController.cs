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
        // GET: api/CategoryViewModel
        public IHttpActionResult Get()
        {
            var result = categoryWCFService.GetCategories();
            return Ok(result);
        }

        // GET: api/CategoryViewModel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CategoryViewModel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CategoryViewModel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CategoryViewModel/5
        public void Delete(int id)
        {
        }
    }
}
