using Microsoft.AspNetCore.Mvc;
using SimpleChatWASM.Shared.API;
using SimpleChatWASM.Shared.Entities;
using SimpleChatWASM.Shared.Repositories;

namespace SimpleChatWASM.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatRoomController : Controller
    {
        private IRoomRepository _roomRepository;
        private IMessageRepository _messageRepository;
        public ChatRoomController(IRoomRepository roomRepository,
                                  IMessageRepository messageRepository)
        {
            _roomRepository = roomRepository;
            _messageRepository=messageRepository;
        }
        /// <summary>
        /// 参加メンバーを指定して、チャットルームを新規作成。
        /// ただし、既に指定メンバーのチャットルームが存在する場合は何もせず、そのチャットルームを返す。
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("create_newroom")]
        public ApiResponse<RoomEntity> CreateNewRoom(List<UserEntity> users)
        {
            var result = new ApiResponse<RoomEntity>();
            try
            {
                var exists_id = _roomRepository.IsExists(users);
                if (exists_id == null)
                {
                    result.data = _roomRepository.CreateRoom(users);
                }
                else
                {
                    result.data = _roomRepository.GetRoom(exists_id.Value);
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 指定ユーザーが参加しているチャットルームを全て取得する。
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("getrooms_byuser")]
        public ApiResponse<List<RoomEntity>> GetRoomsByUser(UserEntity user)
        {
            var result = new ApiResponse<List<RoomEntity>>();
            try
            {
                result.data = _roomRepository.GetRoomsByUser(user);
            }
            catch(Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
        [HttpGet("get_messages")]
        public ApiResponse<List<MessageEntity>> GetMessages(string room_id)
        {
            var result = new ApiResponse<List<MessageEntity>>();
            try
            {
                var long_id = long.Parse(room_id);
                result.data = _messageRepository.GetChatRoomMessages(long_id).ToList();
            }
            catch(Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
    }
}
