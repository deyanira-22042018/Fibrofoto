using Fibrofoto.Data;
using Fibrofoto.Models;

namespace Fibrofoto.Services
{
    public class ClienteRepository: GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(FibrofotoContext context) : base (context)
        { 
        }
    }
}
