using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SocialEvents.ViewModel
{
    public class EventImage
    {
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        public string FileBase64 { get; set; }


    }
}