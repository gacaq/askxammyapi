using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burguers.Askxammy.Api.Data;
using Burguers.Askxammy.Api.Entities.Dtos;
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

        private UnitOfWork unitOfWork = new UnitOfWork(new AskxammyContext());

        /// <summary>
        /// Metodo que obtiene la lista de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClients()
        {
            try
            {
                var clients = this.unitOfWork.clients.Get();

                if (clients.Any())
                {
                    var dtos = clients.Select(x => ClientToDto(x)).ToList();
                    return Ok(dtos);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Obtiene los clientes de a cuerdo al parametro solicitado
        /// </summary>
        /// <param name="id">Id de cliente solicitado</param>
        /// <returns></returns>
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {

                var client = this.unitOfWork.clients.GetById(id);

                if (client != null)
                {
                    return Ok(ClientToDto(client));
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClientDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = DtoToClient(dto);
                    unitOfWork.clients.Update(client);
                    unitOfWork.Save();
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
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody] ClientDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = DtoToClient(dto);
                    unitOfWork.clients.Insert(client);
                    unitOfWork.Save();
                    return Created("AskxammiApi/SaveDish", client);
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
                unitOfWork.clients.Delete(id);
                unitOfWork.Save();

                return Ok("Usuario eliminado");
            }
            else
            {
                return BadRequest("Id de usuario invalido");
            }
        }

        [HttpGet("{id}/dishes")]
        public IActionResult GetDishesByClient(int id)
        {
            if (id > 0)
            {
                var client = unitOfWork.clients.GetById(id);
                if (client != null)
                {
                    return Ok(client.Dish);
                }
                else
                    return BadRequest("El cliente solicitado no existe");
            }
            else
                return BadRequest("El id del restaurante debe ser mayor a 0");
        }


        private Client DtoToClient(ClientDto dto)
        {
            return new Client()
            {
                Id = dto.Id,
                Address = dto.Address,
                Name = dto.Name,
                Username = dto.Username,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role
            };
        }

        private ClientDto ClientToDto(Client client)
        {
            return new ClientDto()
            {
                Id = client.Id,
                Address = client.Address,
                Name = client.Name,
                Username = client.Username,
                Password = client.Password,
                PhoneNumber = client.PhoneNumber,
                Role = client.Role
            };
        }
    }
}
