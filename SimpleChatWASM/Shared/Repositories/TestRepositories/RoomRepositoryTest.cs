using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories.TestRepositories
{
    public class RoomRepositoryTest : IRoomRepository
    {
        public RoomRepositoryTest()
        {

        }

        private List<RoomEntity> _rooms = new List<RoomEntity>() 
        {
            new RoomEntity()
            {
                RoomID=1,
                Members = new List<UserEntity>(){SampleUsers.GetSampleUser("tsuruda"),SampleUsers.GetSampleUser("tanaka")}
            },
            new RoomEntity()
            {
                RoomID = 2,
                Members = new List<UserEntity>(){SampleUsers.GetSampleUser("tsuruda"),SampleUsers.GetSampleUser("satou")}
            },
            new RoomEntity()
            {
                RoomID = 3,
                Members =SampleUsers.GetSampleUsers()
            }
        };

        /// <summary>
        /// 指定のIDのチャットルームが存在するかを確認する
        /// </summary>
        /// <param name="room_id"></param>
        /// <returns></returns>
        public bool IsExists(long room_id)
        {
            return _rooms.Where(w=>w.RoomID==room_id).Any();
        }
        /// <summary>
        /// 指定のメンバーのチャットルームが存在するかを確認し、存在すればそのIDを返す。存在しなければnullを返す。
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public long? IsExists(IEnumerable<UserEntity> members)
        {
            var result = _rooms
                         .Where(w => w.Members.Select(s => s.UserID).SequenceEqual(members.Select(s=>s.UserID)))
                         .FirstOrDefault();
            return result?.RoomID;
        }
        /// <summary>
        /// IDからチャットルームを取得する。
        /// </summary>
        /// <param name="room_id"></param>
        /// <returns></returns>
        public RoomEntity GetRoom(long room_id)
        {
            var result = _rooms.Where(w => w.RoomID==room_id).FirstOrDefault();
            if(result == null)
            {
                throw new Exception($"指定されたIDのチャットが存在しません。[id={room_id}]");
            }
            else
            {
                return result;
            }
        }
        /// <summary>
        /// 指定メンバーのチャットルームを新規作成する
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public RoomEntity CreateRoom(IEnumerable<UserEntity> members)
        {
            var room = new RoomEntity();
            room.Members = members;
            room.RoomID = _rooms.Count + 1;
            _rooms.Add(room);
            return room;
        }
        /// <summary>
        /// 指定ユーザーが参加しているチャットルームを取得する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<RoomEntity> GetRoomsByUser(UserEntity user)
        {
            var result = _rooms.Where(w => w.Members.Select(s => s.UserID).Contains(user.UserID)).ToList();
            return result;
        }
    }
}
