using SimpleChatWASM.Shared.Entities;
using SimpleChatWASM.Shared.Repositories;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using SimpleChatWASM.Shared.API;

namespace SimpleChatWASM.Client.Models.APIAgents
{
    public static class ChatRoomControllerAgent
    {
        public static async Task<RoomEntity> CreateNewRoom(HttpClient httpClient, List<UserEntity> members)
        {
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            try
            {
                var http_ret = await httpClient.PostAsJsonAsync<List<UserEntity>>($"ChatRoom/create_newroom", members, options: options);
                var convert_ret = http_ret.Content.ReadFromJsonAsync<ApiResponse<RoomEntity>>().Result;
                if(string.IsNullOrEmpty(convert_ret.message) == false)
                {
                    throw new Exception(convert_ret.message);
                }
                return convert_ret.data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static async Task<List<RoomEntity>> GetRoomsByUser(HttpClient httpClient,UserEntity user)
        {
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            try
            {
                var http_ret = await httpClient.PostAsJsonAsync<UserEntity>($"ChatRoom/getrooms_byuser", user, options: options);
                var convert_ret = http_ret.Content.ReadFromJsonAsync<ApiResponse<List<RoomEntity>>>().Result;
                if (string.IsNullOrEmpty(convert_ret.message) == false)
                {
                    throw new Exception(convert_ret.message);
                }
                return convert_ret.data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        } 
        public static async Task<List<MessageEntity>> GetChatRoomMessages(HttpClient httpClient,RoomEntity roomEntity)
        {
            var result = await httpClient.GetFromJsonAsync<ApiResponse<List<MessageEntity>>>($"ChatRoom/get_messages?room_id={roomEntity.RoomID}");
            if(string.IsNullOrEmpty(result.message) == false)
            {
                throw new Exception(result.message);
            }
            return result.data;
        }
    }
}
