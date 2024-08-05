using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProduct(bool trackChanges);
        ProductDto GetProductById(int id, bool trackChanges);
        ProductDto CreateOneProduct(ProductDtoForInsertion productdto);
        void UpdateOneProduct(int id, ProductDtoForUpdate productdto, bool trackChanges);
        void DeleteOneProduct(int id, bool trackChanges);

    }
}
