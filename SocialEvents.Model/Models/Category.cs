using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SocialEvents.Model
{
    public class Category : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Category", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(20, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Color", ResourceType = typeof(Resources.Resources))]
        public string Color { get; set; }

        [Display(Name = "EventImage", ResourceType = typeof(Resources.Resources))]
        public EventImage EventImage { get; set; }

        //relation 
        public virtual ICollection<Event> Events { get; set; }


    }
}