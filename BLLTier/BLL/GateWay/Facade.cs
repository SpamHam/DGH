using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BEModels;

namespace BLL.Gateway
{
    internal class Facade
    {
        private IGenericGateway<GenreDTO> GenreGateway;

        public IGenericGateway<GenreDTO> GetGenreGateway()
        {
            return GenreGateway != null ? GenreGateway : GenreGateway = new GenericGateway<GenreDTO>();
        }
    }
}
