using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository.Interfaces
{
    public interface IUserRepository : IRepository<Guid, User>
    {
        Task<List<User>> GetUsersFilter(string filter, KindOfFilter kof);
    }
}
