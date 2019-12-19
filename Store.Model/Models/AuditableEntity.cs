using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ScaffoldColumn(false)]
        public virtual Guid Id { get; set; }

        [Display(Name = "CreatedOn", ResourceType = typeof(Resources.Resources))]

        [ScaffoldColumn(false)]
        public virtual DateTime? CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "UpdatedOn", ResourceType = typeof(Resources.Resources))]
        public virtual DateTime? UpdatedOn { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.Resources))]
        public virtual string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.Resources))]
        public virtual string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]

        //[LocalizedDisplayName("Active")]
        [Display(Name = "Active", ResourceType = typeof(Resources.Resources))]
        public virtual bool Active { get; set; }

        //NotMapped
        public string CreatedOnFormated
        {
            get
            {
                if (CreatedOn.HasValue)
                {
                    string date = CreatedOn.Value.ToString("R", System.Threading.Thread.CurrentThread.CurrentCulture);
                    DateTime convertedDate = DateTime.Parse(date);
                    return convertedDate.ToString();
                }
                return "";

            }
        }
        public string UpdatedOnFormated
        {
            get
            {
                if (UpdatedOn.HasValue)
                {
                    string date = UpdatedOn.Value.ToString("R", System.Threading.Thread.CurrentThread.CurrentCulture);
                    DateTime convertedDate = DateTime.Parse(date);
                    return convertedDate.ToString();
                }
                return "";

            }
        }
    }
}
