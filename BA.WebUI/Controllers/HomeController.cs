using AutoMapper;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using BA.WebUI.ViewModels.BlogViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            var blogs = _blogService.GetBlogList();
            var vm = Mapper.Map<IEnumerable<BlogDetailsViewModel>>(blogs);

            return View("Blogs", vm);
        }

        public ActionResult Details(int id)
        {
            var blog = _blogService.Get(id);

            if (blog == null)
                return HttpNotFound();

            var vm = Mapper.Map<BlogViewModel>(blog);

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.GetUserName();
                vm.UserName = user;
            }

            return View(vm);
        }

        // GET: BlogDetails/Create
        public ActionResult Create()
        {
            return View(new BlogViewModel());
        }

        // POST: BlogDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBlogViewModel createBlog)
        {
            if (!ModelState.IsValid)
                return View(createBlog);

            var blogDetails = Mapper.Map<BlogDto>(createBlog);
            _blogService.Create(blogDetails);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var blog = _blogService.Get(id);

            var blogDetailsViewModel = Mapper.Map<BlogDto, UpdateBlogViewModel>(blog);

            if (blogDetailsViewModel == null)
            {
                return HttpNotFound();
            }

            return View(blogDetailsViewModel);
        }

        // POST: BlogDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateBlogViewModel blogUpdate)
        {
            if (ModelState.IsValid)
            {
                var blogDetails = Mapper.Map<BlogDto>(blogUpdate);
                _blogService.Edit(blogDetails);

                return RedirectToAction("Index");
            }
            return View(blogUpdate);
        }

        //do a method to add comments
        // do method to add like 
    }
}