using System;

namespace SocialEvents.Model
{
    public class Gadget : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }

        //relatins
        public virtual Category Category { get; set; }
    }
}