using SimpleChatWASM.Shared.API;
using SimpleChatWASM.Shared.Entities;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace SimpleChatWASM.Client.Models.APIAgents
{
    public static class UserControllerAgent
    {
        public static async Task<UserEntity> GetUserById(HttpClient httpClient, string user_id)
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<UserEntity>>($"User/getuser_byid?user_id={user_id}");
            if (string.IsNullOrEmpty(response.message) == false)
            {
                throw new Exception(response.message);
            }
            return response.data;            
        }

        public static async Task<List<UserEntity>> GetAllUsers(HttpClient httpClient)
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<List<UserEntity>>>($"User/get_alluser");
            if (string.IsNullOrEmpty(response.message) == false)
            {
                throw new Exception(response.message);
            }
            return response.data;
        }
    }
}
