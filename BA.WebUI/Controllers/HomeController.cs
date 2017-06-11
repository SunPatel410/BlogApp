using AutoMapper;
using BA.Services.Dtos;
using BA.Services.Services;
using BA.WebUI.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogService _blogService;

        public HomeController(BlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            //var blogs = _blogService.GetBlogList();
            //var viewModel = Mapper.Map<BlogViewModel>(blogs);

            var viewModel = Mapper.Map<IEnumerable<BlogDetailsDto>, IEnumerable<BlogViewModel>>(_blogService.GetBlogList());

            return View(viewModel);
        }

    }
}