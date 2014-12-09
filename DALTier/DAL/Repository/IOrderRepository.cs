using System.Collections.Generic;
using DAL.DTOModels;

namespace DAL.Repository
{
        public interface IOrderRepository: IGenericRepository<OrderDTO>
        {
            IEnumerable<OrderModelDTO> GetViewModel();
        }
}
