using SocialEvents.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialEvents.Web.ViewModels
{
    public class ApprovalViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public StateEnum State { get; set; }

        [Display(Name = "Reaseon", ResourceType = typeof(Resources.Resources))]
        public string Reason { get; set; }
    }
}
