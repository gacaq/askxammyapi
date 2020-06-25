using Burguers.Askxammy.Api.Data;
using Burguers.Askxammy.Api.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Burguers.Askxammy.Api.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AskxammyContext _context;
        private IRepository<Client> _clients;
        private IRepository<Dish> _dishes;
        private IRepository<FavoriteDishes> _favoriteDishes;

        public UnitOfWork(AskxammyContext context)
        {
            this._context = context;
        }

        public IRepository<Client> clients
        {
            get
            {
                return _clients ?? (_clients = new BaseRepository<Client>(this._context));
            }
        }

        public IRepository<Dish> dishes
        {
            get
            {
                return _dishes ?? (_dishes = new BaseRepository<Dish>(this._context));
            }
        }

        public IRepository<FavoriteDishes> favoriteDishes
        {
            get
            {
                return _favoriteDishes ?? (_favoriteDishes = new BaseRepository<FavoriteDishes>(this._context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
