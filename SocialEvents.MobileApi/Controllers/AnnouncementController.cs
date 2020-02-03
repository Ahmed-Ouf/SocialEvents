using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialEvents.ViewModel;

namespace SocialEvents.MobileApi.Controllers
{
    public class AnnouncementController : ApiController
    {
        private readonly AnnouncementDmzServiceRef.IAnnouncementWCFService announcementWCFService;
        public AnnouncementController()
        {
            announcementWCFService = new AnnouncementDmzServiceRef.AnnouncementWCFServiceClient();
        }
        // GET: api/Announcement
        public IEnumerable<Announcement> Get()
        {
            var result = announcementWCFService.GetAnnouncements();
            return result;
        }

        // GET: api/Announcement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Announcement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Announcement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Announcement/5
        public void Delete(int id)
        {
        }
    }
}
