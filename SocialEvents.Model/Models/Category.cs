using System;
using System.Collections.Generic;

namespace SocialEvents.Model
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }

        public string Color { get; set; }
        public EventImage EventImage { get; set; }

      
    }

    public class EventImage
    {
        public string FullName { get; set; }
   
    }
}