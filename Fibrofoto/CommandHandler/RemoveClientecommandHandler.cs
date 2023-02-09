using Fibrofoto.Configuration;
using Microsoft.Extensions.Internal;

namespace Fibrofoto.CommandHandler
{
    public class RemoveClientecommandHandler : ICommandHandler<RemoveByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveClientecommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(RemoveByIdCommand command)
        {
            _unitOfWork.Cliente.Delete(command.Id);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Cliente added succesfully" };
        }
    }
}
