using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burguers.Askxammy.Api.Data;
using Burguers.Askxammy.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burguers.Askxammy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private AskxammyContext _context;
        private IUnitOfWork _unitOfWork;

        public DishesController(AskxammyContext context, IUnitOfWork unitOfWork)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetDishes()
        {
            var dishes = this._unitOfWork.dishes.Get();

            if (dishes.Any())
            {
                return Ok(dishes);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("id")]
        public IActionResult GetById(int id)
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
    }
}
