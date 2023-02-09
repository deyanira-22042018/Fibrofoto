using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fibrofoto.Data;
using Fibrofoto.Models;
using Fibrofoto.Commands;
using Fibrofoto.QueryHandler;
using Fibrofoto.DTOS;

namespace Fibrofoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly ICommandHandler<ClienteDTO> _ClienteCommandHandler;
        private readonly ICommandHandler<RemoveByIdCommand> _removeCommandHandler;
        private readonly IQueryHandler<Cliente, QueryByIdCommand> _ClienteQueryHandler;

        public PermissionsController(
            ICommandHandler<ClienteDTO> ClienteCommandHandler,
            ICommandHandler<RemoveByIdCommand> removeCommandHandler,
            IQueryHandler<Cliente, QueryByIdCommand> ClienteQueryHandler
            )
        {
            _ClienteCommandHandler = ClienteCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _ClienteQueryHandler = ClienteQueryHandler;
            _kafkaProducerHandler = kafkaProducerHandler;
        }

        // GET: api/Permissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetPermission()
        {
            _kafkaProducerHandler.WriteMessage("GET");
            var permissions = await _ClienteQueryHandler.GetAll();
            return Ok(Cliente);
        }

        // GET: api/Permissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetPermission(int id)
        {
            _kafkaProducerHandler.WriteMessage("GET");
            var Cliente = await _ClienteQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            });

            if (Cliente == null)
            {
                return NotFound();
            }

            return Ok(Cliente);
        }

        // PUT: api/Permissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO Cliente)
        {
            _kafkaProducerHandler.WriteMessage("PUT");
            if (id != Cliente.Id)
            {
                return BadRequest();
            }

            _ClienteCommandHandler.Execute(Cliente);
            return NoContent();
        }

        // POST: api/Permissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostPermission(ClienteDTO Cliente)
        {
            _kafkaProducerHandler.WriteMessage("POST");
            _ClienteCommandHandler.Execute(Cliente);
            return CreatedAtAction("GetPermission", new { id = Cliente.Id }, Cliente);
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            _kafkaProducerHandler.WriteMessage("DELETE");
            _removeCommandHandler.Execute(new RemoveByIdCommand()
            {
                Id = id
            });
            return NoContent();
        }

    }
}
