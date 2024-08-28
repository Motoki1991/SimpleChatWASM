

namespace SimpleChatWASM.Shared.Entities
{
    public class RoomEntity
    {
        public long RoomID { get; set; }

        public string? RoomName { get; set; }

        public IEnumerable<UserEntity> Members { get; set; } = new List<UserEntity>();

        public MessageEntity? LastMessage { get; set; }                
    }
}
