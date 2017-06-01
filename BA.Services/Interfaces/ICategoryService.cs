using BA.Services.Dtos;
using System.Collections.Generic;

namespace BA.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> Get();
        void AddCategory(CategoryDto categoryDto);
        void RemoveCategory(CategoryDto category);
        void UpdateCategory(CategoryDto category);
    }
}
