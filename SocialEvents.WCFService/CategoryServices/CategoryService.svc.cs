using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SocialEvents.Model;

namespace SocialEvents.WCFService
{
    public class CategoryService : ICategoryService
    {

        public CategoryService()
        {

        }

        public IEnumerable<Category> GetActiveCategories()
        {
            return null;
        }
    }
}
