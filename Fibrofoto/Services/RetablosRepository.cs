using Fibrofoto.Data;
using Fibrofoto.Models;

namespace Fibrofoto.Services
{
    public class RetablosRepository: GenericRepository<Retablos>, IRetablosRepository
    {
        public RetablosRepository(FibrofotoContext context) : base(context)
        { 

        }
    }
}
