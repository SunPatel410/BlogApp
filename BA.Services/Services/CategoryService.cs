using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using System.Collections.Generic;

namespace BA.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> Get()
        {
            var category = _categoryRepository.Get();

            return Mapper.Map<IEnumerable<CategoryDto>>(category);
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = Mapper.Map<Category>(categoryDto);

            _categoryRepository.Add(category);
        }

        public void RemoveCategory(CategoryDto categoryDto)
        {
            var category = _categoryRepository.Get(categoryDto.Id);

            _categoryRepository.Remove(category);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _categoryRepository.Get(categoryDto.Id);
            _categoryRepository.Update(category);
        }
    }
}
