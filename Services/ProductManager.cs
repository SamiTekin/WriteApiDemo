using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public ProductDto CreateOneProduct(ProductDtoForInsertion productdto)
        {
            var entity = _mapper.Map<Product>(productdto);
            _manager.Product.CreateOneProduct(entity);
            _manager.Save();
            return _mapper.Map<ProductDto>(entity);
        }

        public void DeleteOneProduct(int id, bool trackChanges)
        {
            var entity = _manager.Product.GetProductsById(id, trackChanges);
            if (entity == null)
            {
                throw new ProductNotFoundException(id);
            }
            _manager.Product.DeleteOneProduct(entity);
            _manager.Save();
        }

        public IEnumerable<ProductDto> GetAllProduct(bool trackChanges)
        {
            var products= _manager.Product.GetAllProducts(trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductById(int id, bool trackChanges)
        {
            var product= _manager.Product.GetProductsById(id, trackChanges);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return _mapper.Map<ProductDto>(product);
        }

        public void UpdateOneProduct(int id, ProductDtoForUpdate productdto, bool trackChanges)
        {
            var entity = _manager.Product.GetProductsById(id, trackChanges);
            if(entity == null)
            {
                throw new ProductNotFoundException(id);
            }

            /* Mapping */
            entity = _mapper.Map<Product>(productdto);

            _manager.Product.Update(entity);
            _manager.Save();
        }
    }
}
