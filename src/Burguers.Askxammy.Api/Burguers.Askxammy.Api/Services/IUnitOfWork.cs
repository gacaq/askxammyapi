using Burguers.Askxammy.Api.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burguers.Askxammy.Api.Services
{
    public interface IUnitOfWork
    {
        IRepository<Client> clients { get; }
        IRepository<Dish> dishes { get; }
        IRepository<FavoriteDishes> favoriteDishes { get; }

        void Save();
    }
}
