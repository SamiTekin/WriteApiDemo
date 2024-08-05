using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WriteApiDemo.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForInsertion, Product>();
        }
    }
}
