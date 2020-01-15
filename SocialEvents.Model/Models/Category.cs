using System;
using System.Collections.Generic;

namespace SocialEvents.Model
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual List<Gadget> Gadgets { get; set; }

        public Category()
        {
            DateCreated = DateTime.Now;
        }
    }
}