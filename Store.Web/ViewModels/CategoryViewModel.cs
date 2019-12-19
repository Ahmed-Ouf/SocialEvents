﻿using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<GadgetViewModel> Gadgets { get; set; }
    }
}