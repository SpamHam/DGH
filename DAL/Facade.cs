using DAL.DTOModels;
using DAL.Repository;
using DAL.Repository.Impl;

namespace DAL
{
    public class Facade
    {
        private IGenericRepository<ProductDTO> _productRepository;

        public Facade()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IGenericRepository<ProductDTO> GetProductRepository()
        {
            return _productRepository != null ? _productRepository : _productRepository = new ProductRepository();
        }
    }
}
