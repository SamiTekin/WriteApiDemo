using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Product product)
        {
            Create(product);
        }

        public void DeleteOneProduct(Product product)
        {
            Delete(product);
        }

        public IQueryable<Product> GetAllProducts(bool trackChages)
        {
            return FindAll(trackChages).OrderBy(x => x.Id);
        }

        public Product GetProductsById(int id ,bool trackChanges)
        {
            return FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
        }

        public void UpdateOneProduct(Product product)
        {
           Update(product);
        }
    }
}
