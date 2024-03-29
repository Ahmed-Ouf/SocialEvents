﻿using Beneficiary.Web.Helpers;
using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    [RoleAuthorize(Roles = "SocialEventsAdmin")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService CategoryService;
        public CategoryController(ICategoryService Category)
        {
            CategoryService = Category;
        }
        // GET: CategoryViewModel
        public ActionResult Index()
        {
            var list = CategoryService.GetAll();
            return View(list);
        }

        // GET: CategoryViewModel/Details/5
        public ActionResult Details(Guid id)
        {
            var model = CategoryService.GetById(id);

            return View(model);
        }

        // GET: CategoryViewModel/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategoryViewModel/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConvertFileToBase64(model);
                    CategoryService.Add(model.Category);
                    CategoryService.SaveChanges();
                }
                else
                {
                    return View(model);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: CategoryViewModel/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = CategoryService.GetById(id);
            CategoryViewModel vm = new CategoryViewModel { Category = model };
            return View(vm);
        }

        // POST: CategoryViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                ModelState.Remove("File");
               // TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    ConvertFileToBase64(model);
                    CategoryService.Update(model.Category);
                    CategoryService.SaveChanges();

                }
                else
                {
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void ConvertFileToBase64(CategoryViewModel model)
        {
            if (model.File != null && model.File.ContentLength > 0)
            {
                model.Category.EventImage = new EventImage();
                Stream fs = model.File.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((int)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                model.Category.EventImage.FileBase64 = base64String;
                model.Category.EventImage.Name = model.File.FileName;
            }
        }

        // GET: CategoryViewModel/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = CategoryService.GetById(id);
            return View(model);
        }

        // POST: CategoryViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(Category model)
        {
            try
            {
                // TODO: Add delete logic here

                CategoryService.Deactivate(model); 
                CategoryService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Activate(Guid id)
        {
            var model = CategoryService.GetById(id);
            CategoryService.Activate(model);
            CategoryService.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeActivate(Guid id)
        {
            var model = CategoryService.GetById(id);
            CategoryService.Deactivate(model);
            CategoryService.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
