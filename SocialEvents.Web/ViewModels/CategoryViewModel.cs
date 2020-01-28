using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SocialEvents.Web.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }


        public byte[] ImageBytes { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public HttpPostedFileBase File { get; set; }
    }
}