using System.ComponentModel.DataAnnotations;

namespace SocialEvents.ViewModel
{ 
    public class Notification : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Notification", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }
    }
}
