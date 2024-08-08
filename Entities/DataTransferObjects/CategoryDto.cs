using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CategoryDto()
    {
        public int CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string CategoryDescription { get; init; }
        public int? ParentCategoryId { get; init; }
        public Category ParentCategory { get; init; }
        public ICollection<Category> ChildCategories { get; init; }
        public ICollection<Product> Products { get; init; }
    }
}
