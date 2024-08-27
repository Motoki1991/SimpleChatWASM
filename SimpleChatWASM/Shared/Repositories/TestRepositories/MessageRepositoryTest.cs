
using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories.TestRepositories
{
    public class MessageRepositoryTest : IMessageRepository
    {
        private List<MessageEntity> _messages;
        private RoomRepositoryTest _roomRepository = new RoomRepositoryTest(); //これはテストデータつくるためだけの便宜的なもの。本稼働では依存させない。
        public MessageRepositoryTest()
        {
            _messages = new List<MessageEntity>() 
            {
                new MessageEntity()
                {
                    Contents="おはようございます。",
                    Room=_roomRepository.GetRoom(1),
                    User=SampleUsers.GetSampleUser("tanaka"),
                    InputDateTime=new DateTime(2024,3,20,10,35,0)
                },
                new MessageEntity()
                {
                    Contents="お疲れ様です。",
                    Room=_roomRepository.GetRoom(1),
                    User=SampleUsers.GetSampleUser("tsuruda"),
                    InputDateTime=new DateTime(2024,3,20,10,36,0)
                },
                new MessageEntity()
                {
                    Contents="調子はどうですか。",
                    Room=_roomRepository.GetRoom(1),
                    User=SampleUsers.GetSampleUser("tanaka"),
                    InputDateTime=new DateTime(2024,3,20,15,35,0)
                },
                new MessageEntity()
                {
                    Contents="問題ありません。",
                    Room=_roomRepository.GetRoom(1),
                    User=SampleUsers.GetSampleUser("tsuruda"),
                    InputDateTime=new DateTime(2024,3,20,17,35,0)
                },

                new MessageEntity()
                {
                    Contents="こんにちは。",
                    Room=_roomRepository.GetRoom(2),
                    User=SampleUsers.GetSampleUser("tsuruda"),
                    InputDateTime=new DateTime(2024,3,20,10,35,0)
                },
                new MessageEntity()
                {
                    Contents="こんばんは。",
                    Room=_roomRepository.GetRoom(2),
                    User=SampleUsers.GetSampleUser("satou"),
                    InputDateTime=new DateTime(2024,3,20,20,35,0)
                },

                new MessageEntity()
                {
                    Contents="こんにちは。",
                    Room=_roomRepository.GetRoom(3),
                    User=SampleUsers.GetSampleUser("tsuruda"),
                    InputDateTime=new DateTime(2024,3,20,12,35,0)
                },
                new MessageEntity()
                {
                    Contents="あいうえお。",
                    Room=_roomRepository.GetRoom(3),
                    User=SampleUsers.GetSampleUser("tanaka"),
                    InputDateTime=new DateTime(2024,3,20,14,35,0)
                },
                new MessageEntity()
                {
                    Contents="かきくけこ。",
                    Room=_roomRepository.GetRoom(3),
                    User=SampleUsers.GetSampleUser("satou"),
                    InputDateTime=new DateTime(2024,3,20,16,35,0)
                },
            };
        }

        public IEnumerable<MessageEntity> GetChatRoomMessages(long room_id)
        {
            return _messages.Where(w=>w.Room.RoomID==room_id);
        }

        public MessageEntity InsertMessage(MessageEntity message)
        {
            _messages.Add(message);
            return message;
        }

    }
}
