using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<(IEnumerable<ExpandoObject> categories, MetaData metaData)> GetAllCategoryAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<CategoryDto> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDto);
        Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto,bool trackChanges);
        Task DeleteCategoryByIdAsync(int id, bool trackChanges);

    }
}
