using System.ComponentModel.DataAnnotations;

namespace SocialEvents.Model
{
    public class Department : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }
    }
}
