using AutoMapper;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.Services.Requests;
using BA.WebUI.ViewModels;
using BA.WebUI.ViewModels.BlogViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public HomeController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var blogs = _blogService.GetBlogList();
            var vm = Mapper.Map<IEnumerable<BlogViewModel>>(blogs);

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var blog = _blogService.Get(id);

            if (blog == null)
                return HttpNotFound();

            var vm = Mapper.Map<BlogDetailsViewModel>(blog);

            return View(vm);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var categories = _categoryService.Get();

            var viewModel = new CreateBlogViewModel(categories);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CreateBlogViewModel viewModel)
        {
            var categories = _categoryService.Get();

            if (!ModelState.IsValid)
            {
                viewModel.Categories = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        
                return View(viewModel);
            }

            var request = Mapper.Map<CreateBlogRequest>(viewModel);
            var blogId = _blogService.Create(request);

            return RedirectToAction("Details", new {id = blogId});
        }

        [HttpGet]
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

        //do a method to add comments
        // do method to add like 
    }
}