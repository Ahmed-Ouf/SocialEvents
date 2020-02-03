using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.ViewModel
{
    public class Announcement : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Announcement", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Display(Name = "Published", ResourceType = typeof(Resources.Resources))]
        public bool Published { get; set; }

        [Display(Name = "EventImage", ResourceType = typeof(Resources.Resources))]
        public EventImage EventImage { get; set; }
    }
}
