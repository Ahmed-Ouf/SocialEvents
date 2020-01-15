using SocialEvents.Data.Configuration;
using SocialEvents.Data.Helpers;
using SocialEvents.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace SocialEvents.Data
{
    public class SocialEventsEntities : DbContext
    {
        public SocialEventsEntities() : base("StoreEntities")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is AuditableEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    AuditableEntity entity = entry.Entity as AuditableEntity;
                    if (entity != null)
                    {
                        string identityName = "";
                        try
                        {
                            identityName = Thread.CurrentPrincipal.Identity.Name;
                        }
                        catch
                        {
                            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                            identityName = Thread.CurrentPrincipal.Identity.Name;
                        }
                        DateTime now = DateTime.UtcNow;
                        if (string.IsNullOrEmpty(identityName))
                        {
                            identityName = "System";
                        }

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = identityName;
                            entity.CreatedOn = now;
                        }
                        else
                        {
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                            entity.UpdatedBy = identityName;
                            entity.UpdatedOn = now;
                        }
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}