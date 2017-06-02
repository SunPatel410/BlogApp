using AutoMapper;
using BA.Domains;
using BA.Infrastructure.Data.Interfaces.Helpers;
using BA.Services.Dtos;
using BA.Services.Interfaces;
using System.Collections.Generic;

namespace BA.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
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

            _unitOfWork.Complete();
        }

        public void RemoveCategory(CategoryDto categoryDto)
        {
            // category = Mapper.Map<Category>(categoryDto);
            var category = _categoryRepository.Get(categoryDto.Id);

            _categoryRepository.Remove(category);

            _unitOfWork.Complete();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _categoryRepository.Get(categoryDto.Id);

            category.Update(categoryDto.Name, categoryDto.CategoryDescription);
            _unitOfWork.Complete();
        }
    }
}
