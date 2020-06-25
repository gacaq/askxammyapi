using System;
using System.Collections.Generic;

namespace Burguers.Askxammy.Api.Entities.Models
{
    public partial class Client
    {
        public Client()
        {
            Dish = new HashSet<Dish>();
            FavoriteDishes = new HashSet<FavoriteDishes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Dish> Dish { get; set; }
        public virtual ICollection<FavoriteDishes> FavoriteDishes { get; set; }
    }
}
