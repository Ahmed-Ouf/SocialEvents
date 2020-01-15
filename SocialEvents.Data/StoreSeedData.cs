using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SocialEvents.Data
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<SocialEventsEntities>
    {
        protected override void Seed(SocialEventsEntities context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));

            context.SaveChanges();
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Id=Guid.Parse("27D737AB-A403-4525-BAFA-6ECED06E9BB1"),
                    Name = "Tablets"
                },
                new Category {
                    Id=Guid.Parse("E8276A7B-DD1B-4C66-882C-680AFAFA8901"),
                    Name = "Laptops"
                },
                new Category {
                    Id=Guid.Parse("3F6CB98B-2D12-45BE-A776-CC57360BA4F5"),
                    Name = "Mobiles"
                }
            };
        }


    }
}