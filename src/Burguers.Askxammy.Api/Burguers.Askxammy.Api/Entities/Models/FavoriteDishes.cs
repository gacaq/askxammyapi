using System;
using System.Collections.Generic;

namespace Burguers.Askxammy.Api.Entities.Models
{
    public partial class FavoriteDishes
    {
        public long ClientId { get; set; }
        public long DishId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
