using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CategoryDto> _shaper;
        public CategoryManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<CategoryDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDto)
        {
            var entity= _mapper.Map<Category>(categoryDto);
            _manager.Category.CreateOneCategory(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task DeleteCategoryByIdAsync(int id, bool trackChanges)
        {
            var entity= await _manager.Category.GetCategoryByIdAsync(id, trackChanges);
            if (entity != null)
            {
                throw new CategoryNotFoundException(id);
            }
            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> categories, MetaData metaData)> GetAllCategoryAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var categoryWithMetaData= await _manager.Category.GetAllCategoryAsync(categoryParameters, trackChanges);
            var categoryDto= _mapper.Map<IEnumerable<CategoryDto>>(categoryWithMetaData);
            var sapedData = _shaper.ShapeData(categoryDto, categoryParameters.Fields);
            return (categories: sapedData, categoryWithMetaData.MetaData);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetCategoryByIdAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
        {
            var entity = await _manager.Category.GetCategoryByIdAsync(id, trackChanges);
            if(entity is null)
                throw new CategoryNotFoundException(id);
            entity=_mapper.Map<Category>(entity);
            await _manager.SaveAsync();
        }
    }
}
