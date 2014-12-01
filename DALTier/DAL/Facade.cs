using DAL.DTOModels;
using DAL.Repository;
using DAL.Repository.Impl;

namespace DAL
{
    public class Facade
    {
        private IGenericRepository<ProductDTO> _productRepository;
        private IGenericRepository<OrderDTO> _orderRepository;
        private IGenericRepository<OrderLineDTO> _orderLineRepository;
        private IGenericRepository<CategoryDTO> _categoryRepository;

        public Facade()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IGenericRepository<ProductDTO> GetProductRepository()
        {
            return _productRepository != null ? _productRepository : _productRepository = new ProductRepository();
        }
        public IGenericRepository<OrderDTO> GetOrderRepository()
        {
            return _orderRepository != null ? _orderRepository : _orderRepository = new OrderRepository();
        }
        public IGenericRepository<OrderLineDTO> GetOrderLineRepository()
        {
            return _orderLineRepository != null ? _orderLineRepository : _orderLineRepository = new OrderLineRepository();
        }
        public IGenericRepository<CategoryDTO> GetCategoryRepositroy()
        {
            return _categoryRepository != null ? _categoryRepository : _categoryRepository = new CategoryRepository();
        }
    }
}
