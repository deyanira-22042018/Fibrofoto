using Fibrofoto.Commands;
using Fibrofoto.Configuration;
using Fibrofoto.Models;

namespace Fibrofoto.QueryHandler
{
    public class ClienteQueryHandler : IQueryHandler<Cliente, QueryByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _unitOfWork.Cliente.All();
        }

        public async Task<Cliente> GetOne(QueryByIdCommand query)
        {
            return await _unitOfWork.Cliente.GetById(query.Id);
        }
    }
}
