using System.Collections.Generic;
using DAL.DTOModels;

namespace DAL.Repository
{
        public interface IOrderRepository
        {
            OrderDTO Get(int id);

            IEnumerable<OrderDTO> GetAll();

            void Add(OrderDTO orderDTO);

            void Update(OrderDTO orderDTO);

            void Delete(int id);

            IEnumerable<OrderModelDTO> GetViewModel();
        }
}
