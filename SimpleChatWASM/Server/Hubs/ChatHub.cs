using Microsoft.AspNetCore.SignalR;
using SimpleChatWASM.Shared.Entities;
using SimpleChatWASM.Shared.Repositories;

namespace SimpleChatWASM.Server.Hubs
{
    public class ChatHub:Hub
    {
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        private IRoomRepository _roomRepository;
        private IInformationRepository _informationRepository;

        private Dictionary<string,List<string>> ConnectedUsers = new Dictionary<string,List<string>>();

        public ChatHub(IUserRepository userRepository, 
            IRoomRepository roomRepository, 
            IInformationRepository informationRepository,
            IMessageRepository messageRepository)
        {
            _userRepository=userRepository;
            _roomRepository=roomRepository;
            _informationRepository=informationRepository;
            _messageRepository=messageRepository;
        }

        public override Task OnConnectedAsync()
        {
            var id = this.Context.UserIdentifier;
            //MyUsers.TryAdd(Context.ConnectionId, new MyUserType() { ConnectionId = Context.ConnectionId });

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception ex)
        {
            //MyUserType garbage;

            //MyUsers.TryRemove(Context.ConnectionId, out garbage);

            return base.OnDisconnectedAsync(ex);
        }

        public async Task SendMessage(MessageEntity message,RoomEntity room) 
        {
            room.LastMessage = message;
            _messageRepository.InsertMessage(message);


        }
    }
}
