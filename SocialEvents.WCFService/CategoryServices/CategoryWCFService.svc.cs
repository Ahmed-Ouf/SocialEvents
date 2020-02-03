using System.Collections.Generic;
using System.Linq;
using vm = SocialEvents.ViewModel;
using SocialEvents.Service;

namespace SocialEvents.WCFService
{
    public class CategoryWCFService : ICategoryWCFService
    {

        private readonly ICategoryService _CategoryService;
        public CategoryWCFService(ICategoryService Category)
        {
            _CategoryService = Category;
        }

        public IEnumerable<vm.Category> GetCategories()
        {
            var result= _CategoryService.GetAllAtive().Select(e => new vm.Category
            {

                Id = e.Id,
                Name = e.Name,
                EventImage = new vm.EventImage
                {
                    Name = e.EventImage.Name,
                    FileBase64 = e.EventImage.FileBase64
                }

            }).ToList();


            return result;
        }
    }
}
