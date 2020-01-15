using SocialEvents.Model;
using System.Data.Entity.ModelConfiguration;

namespace SocialEvents.Data.Configuration
{
    public class GadgetConfiguration : EntityTypeConfiguration<Gadget>
    {
        public GadgetConfiguration()
        {
            ToTable("Gadgets");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Price).IsRequired().HasPrecision(8, 2);
            Property(g => g.CategoryId).IsRequired();

            HasRequired(e => e.Category).WithMany(e => e.Gadgets).HasForeignKey(e => e.CategoryId).WillCascadeOnDelete(false);
        }
    }
}