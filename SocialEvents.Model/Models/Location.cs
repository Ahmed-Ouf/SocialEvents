using System.ComponentModel.DataAnnotations;

namespace SocialEvents.Model
{
    public class Location : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Longitude", ResourceType = typeof(Resources.Resources))]
        public string Longitude { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Latitude", ResourceType = typeof(Resources.Resources))]
        public string Latitude { get; set; }

    }
}
