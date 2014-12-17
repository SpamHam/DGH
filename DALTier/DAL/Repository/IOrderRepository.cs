using System.Collections.Generic;
using DAL.DTOModels;

namespace DAL.Repository
{
        public interface IOrderRepository: IGenericRepository<OrderDTO>
        {
            /// <summary>
            /// get a <"OrderModelDTO"> from the database, where it takes from multiple tables.
            /// </summary>
            /// <returns></returns>
            IEnumerable<OrderModelDTO> GetViewModel();
        }
}
