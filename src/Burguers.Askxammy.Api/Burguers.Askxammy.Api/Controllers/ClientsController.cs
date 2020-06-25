using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burguers.Askxammy.Api.Data;
using Burguers.Askxammy.Api.Entities.Models;
using Burguers.Askxammy.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burguers.Askxammy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private AskxammyContext _context;
        private IUnitOfWork _unitOfWork;

        public ClientsController(AskxammyContext context, IUnitOfWork unitOfWork)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = this._unitOfWork.clients.Get();

            if (clients.Any())
            {
                return Ok(clients);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var client = this._unitOfWork.clients.GetById(id);

            if(client != null)
            {
                return Ok(client);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.clients.Update(client);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _unitOfWork.clients.Delete(id);
                _unitOfWork.Save();

                return Ok("Usuario eliminado");
            }
            else
            {
                return BadRequest("Id de usuario invalido");
            }
        }
    }
}
