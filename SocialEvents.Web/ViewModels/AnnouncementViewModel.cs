using SocialEvents.Model;
using SocialEvents.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SocialEvents.Web.ViewModels
{
    public class AnnouncementViewModel
    {
        public Announcement Announcement { get; set; }


        public byte[] ImageBytes { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "File", ResourceType = typeof(Resources.Resources))]
        public HttpPostedFileBase File { get; set; }
    }
}