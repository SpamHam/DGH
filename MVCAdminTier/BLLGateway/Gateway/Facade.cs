﻿using BLLGateway.DTOModels;
using BLLGateway.Gateway.Gateways;

namespace BLLGateway.Gateway
{
    public class Facade
    {
        private IGenericGateway<ProductDTO> _productGateway;
        private IOrderGateway _orderGateway;
        private ICityGateway _cityGateway;
        private IGenericGateway<OrderLineDTO> _orderLineGateway;
        private IGenericGateway<CategoryDTO> _categoryGateway;
        private IGenericGateway<CustomerDTO> _customerGateway;
        private IGenericGateway<AddressDTO> _addressGateway;
       // private IGenericGateway<CityDTO> _cityGateway;

        public IGenericGateway<ProductDTO> GetProductGateway()
        {
            return _productGateway != null ? _productGateway : _productGateway = new GenericGateway<ProductDTO>();
        }

        public IOrderGateway GetOrderGateway()
        {
            return _orderGateway != null ? _orderGateway : _orderGateway = new OrderGateway();
        }

        public IGenericGateway<OrderLineDTO> GetOrderLineGateway()
        {
            return _orderLineGateway != null ? _orderLineGateway : _orderLineGateway = new GenericGateway<OrderLineDTO>();
        }
        public IGenericGateway<CategoryDTO> GetCategoryGateway()
        {
            return _categoryGateway != null ? _categoryGateway : _categoryGateway = new GenericGateway<CategoryDTO>();
        }
        public IGenericGateway<CustomerDTO> GetCustomerGateway()
        {
            return _customerGateway != null ? _customerGateway : _customerGateway = new GenericGateway<CustomerDTO>();
        }

        public IGenericGateway<AddressDTO> GetAddressGateway()
        {
            return _addressGateway != null ? _addressGateway : _addressGateway = new GenericGateway<AddressDTO>();
        }
        public ICityGateway GetCityGateway()
        {
            return _cityGateway != null ? _cityGateway : _cityGateway = new CityGateway();
        } 
    }
}