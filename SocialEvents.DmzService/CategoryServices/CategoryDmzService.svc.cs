using System.Collections.Generic;
using System.Linq;
using vm = SocialEvents.ViewModel;
using SocialEvents.DmzService.CategoryWCFServiceRef;

namespace SocialEvents.DmzService
{
    public class CategoryDmzService : ICategoryWCFService
    {

        private readonly CategoryWCFServiceClient _CategoryService;
        public CategoryDmzService()
        {
            _CategoryService = new CategoryWCFServiceClient();
        }

        public List<vm.Category> GetCategories()
        {
            var result = _CategoryService.GetCategories();


            return result;
        }
    }
}
