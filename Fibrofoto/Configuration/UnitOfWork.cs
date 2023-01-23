using Fibrofoto.Data;
using Fibrofoto.Services;

namespace Fibrofoto.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FibrofotoContext _context;
        public IRetablosRepository RetablosRepository { get; private set; }

        public IClienteRepository ClienteRepository { get; private set; }

        public UnitOfWork(FibrofotoContext context)
        {
            _context= context;
            RetablosRepository = new RetablosRepository(_context);
            ClienteRepository = new ClienteRepository(_context);
        }
        public void commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
