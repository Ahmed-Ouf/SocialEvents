using System.Collections.Generic;
using System.Linq;
using SocialEvents.ViewModel;
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

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var result= _CategoryService.GetAllAtive().Select(e => new CategoryViewModel
            {

                Id = e.Id,
                Name = e.Name,
                EventImage = new EventImageViewModel
                {
                    Name = e.EventImage.Name,
                    FileBase64 = e.EventImage.FileBase64
                }

            }).ToList();


            return result;
        }
    }
}
