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
    public interface IProductService
    {
        Task<(IEnumerable<ExpandoObject>product, MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productdto);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productdto, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanges);

    }
}
