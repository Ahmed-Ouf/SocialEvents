using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEvents.Resources.Helpers;

namespace SocialEvents.ViewModel
{
    public enum StateEnum
    {
        [Display(Name = "Pending", ResourceType = typeof(Resources.Resources))]
        Pending,

        [Display(Name = "Approved", ResourceType = typeof(Resources.Resources))]
        Approved,

        [Display(Name = "Rejected", ResourceType = typeof(Resources.Resources))]
        Rejected
    }

    public enum RegistrationStateEnum
    {
        [Display(Name = "Available", ResourceType = typeof(Resources.Resources))]
        Available,

        [Display(Name = "Completed", ResourceType = typeof(Resources.Resources))]
        Completed,

        [Display(Name = "Expired", ResourceType = typeof(Resources.Resources))]
        Expired,

        [Display(Name = "Closed", ResourceType = typeof(Resources.Resources))]
        Closed
    }

    public class EventViewModel : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public Guid LocationId { get; set; }
        public Guid TargetGroupId { get; set; }
        public Guid DepartmentId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "EventNumber", ResourceType = typeof(Resources.Resources))]
        public string EventNumber { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Event", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resources))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "DateFrom", ResourceType = typeof(Resources.Resources))]
        public DateTime DateFrom { get; set; }
        public string DateFromFormated => DateFrom.ToString("dd/MM/yyyy");

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "DateTo", ResourceType = typeof(Resources.Resources))]
        public DateTime DateTo { get; set; }
        public string DateToFormated => DateTo.ToString("dd/MM/yyyy");

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "TimeFrom", ResourceType = typeof(Resources.Resources))]
        public TimeSpan TimeFrom { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "TimeTo", ResourceType = typeof(Resources.Resources))]
        public TimeSpan TimeTo { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "WeekDays", ResourceType = typeof(Resources.Resources))]
        public string WeekDays { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Fees", ResourceType = typeof(Resources.Resources))]
        public double Fees { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "TargetAge", ResourceType = typeof(Resources.Resources))]
        public string TargetAge { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "EventUrl", ResourceType = typeof(Resources.Resources))]
        public string EventUrl { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "FacebookUrl", ResourceType = typeof(Resources.Resources))]
        public string FacebookUrl { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "twitterUrl", ResourceType = typeof(Resources.Resources))]
        public string twitterUrl { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "InstagramUrl", ResourceType = typeof(Resources.Resources))]
        public string InstagramUrl { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public StateEnum State { get; set; }

        [Display(Name = "RegistrationState", ResourceType = typeof(Resources.Resources))]
        public RegistrationStateEnum RegistrationState { get; set; }

        public string RegistrationStateDescriptionAR
        {
            get
            {
                return ResourcesHelper.GetAR(RegistrationState.GetDisplayName());
            }
            set { return; }
        }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Reaseon", ResourceType = typeof(Resources.Resources))]
        public string Reaseon { get; set; }

        [Display(Name = "Notifiable", ResourceType = typeof(Resources.Resources))]
        public bool Notifiable { get; set; }

        [Display(Name = "Published", ResourceType = typeof(Resources.Resources))]
        public bool Published { get; set; }

        //relation 
        public virtual DepartmentViewModel Department { get; set; }
        public virtual LocationViewModel Location { get; set; }
        public virtual TargetGroupViewModel TargetGroup { get; set; }
        public virtual CategoryViewModel Category { get; set; }

        //not mapped
        [NotMapped]
        [Display(Name = "WeekDays", ResourceType = typeof(Resources.Resources))]
        public int[] DaysOfWeek { get; set; }


    }

   
}
