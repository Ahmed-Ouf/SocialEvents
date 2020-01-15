namespace SocialEvents.Model.Models
{
    public class Location : AuditableEntity
    {
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
