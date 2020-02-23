using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialEvents.ViewModel;

namespace SocialEvents.MobileApi.Controllers
{
    public class TargetGroupController : ApiController
    {
        private readonly TargetGroupDmzServiceRef.ITargetGroupWCFService targetGroupWCFService;
        public TargetGroupController()
        {
            targetGroupWCFService = new TargetGroupDmzServiceRef.TargetGroupWCFServiceClient();
        }
        // GET: api/Event
        public IEnumerable<TargetGroupViewModel> Get()
        {
            var result = targetGroupWCFService.GetTargetGroups();
            return result;
        }

        // GET: api/Event/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
