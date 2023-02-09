

using Fibrofoto.Configuration;
using Fibrofoto.DTOS;
using Fibrofoto.Models;
using Microsoft.Extensions.Internal;

namespace Fibrofoto.CommandHandler
{
    public class AddClienteCommandHandler: ICommandHandler<Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public CommandResult Execute(ClienteDTO Cliente)
        {
            var newPermission = new Cliente()
            {
                Id = Cliente.Id,
                EmployeeForename = Cliente.EmployeeForename,
                EmployeeSurname = Cliente.EmployeeSurname,
                ClientenDate = Cliente.ClienteDate,
                ClienteTypeId = Cliente.ClienteTypeId
            };
            _unitOfWork.Cliente.Add(new Cliente);
            _unitOfWork.Commit();

            return new CommandResult { Status = true, Message = " Cliente added succesfully" };
        }
    }
}
