using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Model
{
    public class TargetGroup : AuditableEntity
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "TargetGroup", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }
    }
}