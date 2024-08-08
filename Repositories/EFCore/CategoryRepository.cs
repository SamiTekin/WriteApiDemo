using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category)
        {
            Create(category);
        }

        public void DeleteOneCategory(Category category)
        {
            Delete(category);
        }

        public async Task<PagedList<Category>> GetAllCategoryAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var categories = await FindAll(trackChanges)
                .Search(categoryParameters.SearchTerm)
                .OrderBy(x => x.CategoryId).ToListAsync();
            return PagedList<Category>.ToPagedList(categories, categoryParameters.PageNumber, categoryParameters.PageSize);
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x=>x.ParentCategoryId==id,trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateOneCategory(Category category)
        {
            Update(category);
        }
    }
}
