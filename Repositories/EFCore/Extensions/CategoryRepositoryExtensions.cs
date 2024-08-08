using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class CategoryRepositoryExtensions
    {
        public static IQueryable<Category> Search(this IQueryable<Category> categories, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return categories;
            var lowerCaseTerm=searchTerm.Trim().ToLower();
            return categories
                .Where(x => x.CategoryName.ToLower().Contains(lowerCaseTerm));
        }
    }
}
