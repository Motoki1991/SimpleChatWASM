using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<MessageEntity> GetChatRoomMessages(long room_id);
        MessageEntity InsertMessage(MessageEntity message);
    }
}
