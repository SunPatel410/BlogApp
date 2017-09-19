using AutoMapper;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.Services.Requests;
using BA.WebUI.ViewModels;
using BA.WebUI.ViewModels.BlogViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = _blogService.GetBlogList();
            var vm = Mapper.Map<IEnumerable<BlogViewModel>>(blogs);

            return View(vm);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            var blog = _blogService.Get(id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            var vm = Mapper.Map<BlogDetailsViewModel>(blog);

            return View(vm);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            var categories = _categoryService.Get();

            var viewModel = new CreateBlogViewModel(categories);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBlogViewModel viewModel)
        {
            var categories = _categoryService.Get();
            viewModel.Categories = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var request = Mapper.Map<CreateBlogRequest>(viewModel);
            request.User = User.Identity.GetUserName();

            _blogService.Create(request);

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var blog = _blogService.Get(id);

            var viewModel = Mapper.Map<BlogDto, UpdateBlogViewModel>(blog);

            if (viewModel == null)
                return HttpNotFound();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateBlogViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var blogDetails = Mapper.Map<BlogDto>(viewModel);
                _blogService.Edit(blogDetails);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //// GET: Blog/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogViewModel blogViewModel = db.BlogViewModels.Find(id);
        //    if (blogViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogViewModel);
        //}

        //// POST: Blog/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    BlogViewModel blogViewModel = db.BlogViewModels.Find(id);
        //    db.BlogViewModels.Remove(blogViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
