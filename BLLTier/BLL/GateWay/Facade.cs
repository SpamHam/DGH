using BLL.DTOModels;

namespace BLL.Gateway
{
    public class Facade
    {
        private IGenericGateway<OrderDTO> _orderGateway;
        private IGenericGateway<OrderLineDTO> _orderLineGateway;
        private IGenericGateway<ProductDTO> _productGateway;
        private IGenericGateway<CategoryDTO> _categoryGateway;

        public IGenericGateway<OrderDTO> GetOrderGateway()
        {
            return _orderGateway != null ? _orderGateway : _orderGateway = new GenericGateway<OrderDTO>();
        }
        public IGenericGateway<OrderLineDTO> GetOrderLineGateway()
        {
            return _orderLineGateway != null ? _orderLineGateway : _orderLineGateway = new GenericGateway<OrderLineDTO>();
        }
        public IGenericGateway<ProductDTO> GetProductGateway()
        {
            return _productGateway != null ? _productGateway : _productGateway = new GenericGateway<ProductDTO>();
        }
        public IGenericGateway<CategoryDTO> GetCategoryGateway()
        {
            return _categoryGateway != null ? _categoryGateway : _categoryGateway = new GenericGateway<CategoryDTO>();
        }
    }
}
