using BLL.DTOModels;

namespace BLL.Gateway
{
    public class Facade
    {
        private IGenericGateway<OrderDTO> _orderGateway;
        private IGenericGateway<OrderLineDTO> _orderLineGateway;

        public IGenericGateway<OrderDTO> GetOrderGateway()
        {
            return _orderGateway != null ? _orderGateway : _orderGateway = new GenericGateway<OrderDTO>();
        }
        public IGenericGateway<OrderLineDTO> GetOrderLineGateway()
        {
            return _orderLineGateway != null ? _orderLineGateway : _orderLineGateway = new GenericGateway<OrderLineDTO>();
        }
    }
}
