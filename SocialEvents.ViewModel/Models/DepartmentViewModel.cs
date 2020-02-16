using System.ComponentModel.DataAnnotations;

namespace SocialEvents.ViewModel
{
    public class DepartmentViewModel : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string DepartmentNameAr { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string DepartmentNameEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string SafeerDepartmentId { get; set; }
    }
}
