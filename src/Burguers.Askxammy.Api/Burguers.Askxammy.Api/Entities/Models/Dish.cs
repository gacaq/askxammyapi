using System;
using System.Collections.Generic;

namespace Burguers.Askxammy.Api.Entities.Models
{
    public partial class Dish
    {
        public Dish()
        {
            FavoriteDishes = new HashSet<FavoriteDishes>();
        }

        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<FavoriteDishes> FavoriteDishes { get; set; }
    }
}
