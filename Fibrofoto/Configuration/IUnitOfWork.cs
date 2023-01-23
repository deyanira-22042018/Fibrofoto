using Fibrofoto.Services;

namespace Fibrofoto.Configuration
{
    public interface IUnitOfWork
    {
        IRetablosRepository RetablosRepository { get; }
        IClienteRepository ClienteRepository { get; }

        void commit ();
        void Dispose ();
    }
}
