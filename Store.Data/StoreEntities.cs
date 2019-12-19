using Store.Data.Configuration;
using Store.Data.Helpers;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
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
