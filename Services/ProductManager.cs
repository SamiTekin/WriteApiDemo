using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private readonly IDataShaper<ProductDto> _shaper;
        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<ProductDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productdto)
        {
            var entity =_mapper.Map<Product>(productdto);
            _manager.Product.CreateOneProduct(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Product.GetProductsByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ProductNotFoundException(id);
            }
            _manager.Product.DeleteOneProduct(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> product, MetaData metaData)> GetAllProductAsync(ProductParameters productParameters, bool trackChanges)
        {
            if(!productParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();
            var productsWithMetaData=await _manager.Product.GetAllProductsAsync(productParameters, trackChanges);
            var productsDto=_mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
            var shapedData= _shaper.ShapeData(productsDto, productParameters.Fields);
            
            return (product:shapedData ,metaData: productsWithMetaData.MetaData);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product=await _manager.Product.GetProductsByIdAsync(id, trackChanges);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productdto, bool trackChanges)
        {
            var entity =await _manager.Product.GetProductsByIdAsync(id, trackChanges);
            if(entity == null)
            {
                throw new ProductNotFoundException(id);
            }

            /* Mapping */
            entity = _mapper.Map<Product>(productdto);

            _manager.Product.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
