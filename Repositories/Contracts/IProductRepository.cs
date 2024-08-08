using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        Task <PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
        Task<Product> GetProductsByIdAsync(int id, bool trackChanges);
        void DeleteOneProduct(Product product);
        void CreateOneProduct(Product product);
        void UpdateOneProduct(Product product);

    }
}
