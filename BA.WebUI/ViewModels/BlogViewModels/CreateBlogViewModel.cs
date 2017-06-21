using AutoMapper;
using BA.Services.Dtos;
using System.Collections.Generic;

namespace BA.WebUI.ViewModels.BlogViewModels
{
    public class CreateBlogViewModel
    {
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateBlogViewModel()
        {
            
        }

        public CreateBlogViewModel(IEnumerable<CategoryDto> categories)
        {
            Categories = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }
    }
}