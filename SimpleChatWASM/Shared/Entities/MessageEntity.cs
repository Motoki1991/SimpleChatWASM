namespace SimpleChatWASM.Shared.Entities
{
    public class MessageEntity
    {
        public MessageEntity() { }

        public RoomEntity Room { get; set; }
        public UserEntity User { get; set; }
        public DateTime InputDateTime { get; set; }
        public string Contents { get; set; }
        public List<string> MentionIDs { get; set; }

        public string GetDate()
        {
            if(InputDateTime == null) { return ""; }
            return InputDateTime.ToString("yyyy/M/d");
        }
    }
}
