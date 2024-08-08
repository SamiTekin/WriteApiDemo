using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper, IDataShaper<ProductDto> productShaper,IDataShaper<UserDto> userShaper, IDataShaper<CategoryDto> categoryShaper)
        {
            _productService = new Lazy<IProductService>(() => new ProductManager(repositoryManager, logger, mapper, productShaper));
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager, logger, mapper,userShaper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager, logger, mapper, categoryShaper));
            
        }
        public IProductService ProductService =>_productService.Value;
        public IUserService UserService =>_userService.Value;
        public ICategoryService CategoryService =>_categoryService.Value;
    }
}
