using DAL.Repository;
using DAL.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Facade
    {
        private IGenericRepository<Product> _productRepository;

        public Facade()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IGenericRepository<Product> GetProductRepository()
        {
            return _productRepository != null ? _productRepository : _productRepository = new ProductRepository();
        }
    }
}
