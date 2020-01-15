using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Model.Models
{
    public class Announcement : AuditableEntity
    {
        public string Name { get; set; }
        public EventImage EventImage { get; set; }
    }
}
