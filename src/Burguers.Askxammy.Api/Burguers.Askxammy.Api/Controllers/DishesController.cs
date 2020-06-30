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
    public class DishesController : ControllerBase
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AskxammyContext());

        /// <summary>
        /// Obtiene la lista de todos los platos disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDishes()
        {
            try
            {
                var dishes = this._unitOfWork.dishes.Get();

                if (dishes.Any())
                {
                    var dtoList = dishes.Select(x => DishToDto(x)).ToList();
                    return Ok(dtoList);
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


        [HttpGet("id")]
        public IActionResult GetById(long id)
        {
            if (id > 0)
            {
                var dishes = this._unitOfWork.dishes.GetById(id);
                if (dishes != null)
                {
                    return Ok(dishes);
                }
                else
                {
                    return NoContent();
                }
            }
            else
                return BadRequest("El id debe ser mayor a cero");
        }

        [HttpPost]
        public IActionResult SaveDish([FromBody] DishDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dish = DtoToDish(dto);
                    _unitOfWork.dishes.Insert(dish);
                    _unitOfWork.Save();
                    return Created("AskxammiApi/SaveDish", dish);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateDish([FromBody] DishDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dish = DtoToDish(dto);
                    _unitOfWork.dishes.Update(dish);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _unitOfWork.dishes.Delete(id);
                    _unitOfWork.Save();

                    return Ok("Plato eliminado");
                }
                else
                {
                    return BadRequest("Id de usuario invalido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        private DishDto DishToDto(Dish dish)
        {
            return new DishDto()
            {
                Id = dish.Id,
                ClientId = dish.ClientId,
                Description = dish.Description,
                Name = dish.Name,
                Price = dish.Price,
                Rate = dish.Rate,
                Type = dish.Type
            };
        }

        private Dish DtoToDish(DishDto dto)
        {
            return new Dish()
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                Description = dto.Description,
                Name = dto.Name,
                Price = dto.Price,
                Rate = dto.Rate,
                Type = dto.Type
            };
        }
    }
}
