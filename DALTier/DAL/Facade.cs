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
        private IGenericRepository<CustomerDTO> _customerRepository;
        private IGenericRepository<CityDTO> _cityRepository;

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
        public IGenericRepository<CategoryDTO> GetCategoryRepository()
        {
            return _categoryRepository != null ? _categoryRepository : _categoryRepository = new CategoryRepository();
        }
        public IGenericRepository<CustomerDTO> GetCustomerRepository()
        {
            return _customerRepository != null ? _customerRepository : _customerRepository = new CustomerRepository();
        }
        public IGenericRepository<CityDTO> GetCityRepository()
        {
            return _cityRepository != null ? _cityRepository : _cityRepository = new CityRepository();
        }
    }
}
