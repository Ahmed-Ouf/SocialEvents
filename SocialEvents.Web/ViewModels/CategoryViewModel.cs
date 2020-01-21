using System;
using System.Collections.Generic;

namespace SocialEvents.Web.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<AnnouncementViewModel> Gadgets { get; set; }
    }
}