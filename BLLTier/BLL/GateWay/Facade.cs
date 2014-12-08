using BLL.DTOModels;
using BLL.GateWay.Gateways;

namespace BLL.Gateway
{
    public class Facade
    {
        private IOrderGateway _orderGateway;
        private IGenericGateway<OrderLineDTO> _orderLineGateway;
        private IGenericGateway<ProductDTO> _productGateway;
        private IGenericGateway<CategoryDTO> _categoryGateway;
        private IGenericGateway<CustomerDTO> _customerGateway;

        public IOrderGateway GetOrderGateway()
        {
            return _orderGateway != null ? _orderGateway : _orderGateway = new OrderGateway();
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
        public IGenericGateway<CustomerDTO> GetCustomerGateway()
        {
            return _customerGateway != null ? _customerGateway : _customerGateway = new GenericGateway<CustomerDTO>();
        }
    }
}
