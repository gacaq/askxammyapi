using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burguers.Askxammy.Api.Entities.Dtos
{
    /// <summary>
    /// Entidad DTO para guardar y devolver desde la api el objeto Dish
    /// </summary>
    public class DishDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }
    }
}
