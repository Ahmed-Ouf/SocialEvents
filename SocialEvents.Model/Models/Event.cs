using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Model.Models
{
    public class Event : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public Guid LocationId { get; set; }
        public Guid TargetGroupId { get; set; }
        public Guid DepartmentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public double Fees { get; set; }
        public string EventUrl { get; set; }
        public string TargetAge { get; set; }
        public bool Notify { get; set; }


    }

}
