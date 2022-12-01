using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<List<User>> GetUsersFilter(string filter, KindOfFilter kof);
        Task<User> GetById(Guid id);
        Task<HttpResponseMessage> Add(User User);
        Task<HttpResponseMessage> Delete(Guid Userid, Guid id);
        Task<HttpResponseMessage> Update(User User);
        
    }
}
