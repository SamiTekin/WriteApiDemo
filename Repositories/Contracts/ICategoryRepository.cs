using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        Task<PagedList<Category>> GetAllCategoryAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<Category> GetCategoryByIdAsync(int id, bool trackChanges);
        void DeleteOneCategory(Category category);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
    }
}
