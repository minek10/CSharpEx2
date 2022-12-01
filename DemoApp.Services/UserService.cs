using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using DemoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Add
        public async Task<HttpResponseMessage> Add(User user)
        {
            try
            {
                var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await _httpClient.PostAsync($"api/user", userJson);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region Delete
        public async Task<HttpResponseMessage> Delete(Guid userid, Guid id)
        {
            try
            {
                HttpResponseMessage result = await _httpClient.DeleteAsync($"api/user/userdelete/{userid}/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<User>>(
                    await _httpClient.GetStreamAsync("api/User"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region GetUsersFilter
        public async Task<List<User>> GetUsersFilter(string filter, KindOfFilter kof)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<List<User>>(
                    await _httpClient.GetStreamAsync($"api/User/filter?filter={filter}&kindOfFilter={kof}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region GetById
        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<User>(
                    await _httpClient.GetStreamAsync($"api/user/{id}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region Update
        public async Task<HttpResponseMessage> Update(User user)
        {
            try
            {
                var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await _httpClient.PutAsync($"api/user", userJson);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion


    }
}