using System.Collections.Generic;
using System.Linq;
using SocialEvents.ViewModel;
using SocialEvents.Service;
using AutoMapper;
using SocialEvents.Model;
using SocialEvents.WCFService.Helpers;

namespace SocialEvents.WCFService
{
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    public class CategoryWCFService : ICategoryWCFService
    {

        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        public CategoryWCFService(ICategoryService Category, IMapper mapper)
        {
            _CategoryService = Category;
            _mapper = mapper;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var entity = _CategoryService.GetAll().ToList();
            var model = _mapper.Map<List<Category>, List<CategoryViewModel>>(entity);
            return model;
        }
    }
}
