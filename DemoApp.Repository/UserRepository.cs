using DemoApp.Data.Context;
using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using DemoApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository
{
    public class UserRepository : Repository<Guid, User>, IUserRepository
    {
        private readonly DemoAppDBContext _context;
        private readonly DbSet<User> _entities;

        public UserRepository(DemoAppDBContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<User>();
        }

        public async override Task<IEnumerable<User>> Get()
        {
            IEnumerable<User> Users = await _entities.Where(x => x.DeleteDate == null).ToListAsync();
            return Users;
        }

        public async override Task<User> GetById(Guid id)
        {
            User User = await _entities.Where(x => x.DeleteDate == null && x.Id == id).FirstOrDefaultAsync();
            return User;
        }

        #region GetUsersFiler
        public async Task<List<User>> GetUsersFilter(string filter, KindOfFilter kof)
        {
            try
            {
                List<User> Users = new();
                
                if (!(string.IsNullOrEmpty(filter)))
                {
                    filter = filter.ToUpper();

                    switch ((int)kof)
                    {
                        //Nom
                        case 1:
                            return Users = await _entities.Where(x => x.DeleteDate == null && (x.FirstName.ToUpper().Contains(filter)))
                                                   .OrderBy(x => x.FirstName)
                                                   .ToListAsync();
                            break;
                        //Prenom
                        case 2:
                            return Users = await _entities.Where(x => x.DeleteDate == null && (x.LastName.ToUpper().Contains(filter)))
                                                   .OrderBy(x => x.FirstName)
                                                   .ToListAsync();
                            break;
                        //Aucun
                        default: 
                            return Users = await _entities.Where(x => x.DeleteDate == null).OrderBy(x => x.FirstName).ToListAsync();
                            break;
                    }
                }
                else
                {
                    return Users = await _entities.Where(x => x.DeleteDate == null).OrderBy(x => x.FirstName).ToListAsync();
                }

                return Users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion

    }
}
