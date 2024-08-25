using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories
{
    public interface IRoomRepository
    {
        /// <summary>
        /// 指定のIDのチャットルームが存在するかを確認する
        /// </summary>
        /// <param name="room_id"></param>
        /// <returns></returns>
        public bool IsExists(long room_id);
        /// <summary>
        /// 指定のメンバーのチャットルームが存在するかを確認し、存在すればそのIDを返す。存在しなければnullを返す。
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public long? IsExists(IEnumerable<UserEntity> members);
        /// <summary>
        /// IDからチャットルームを取得する。
        /// </summary>
        /// <param name="room_id"></param>
        /// <returns></returns>
        public RoomEntity GetRoom(long room_id);
        /// <summary>
        /// 指定メンバーのチャットルームを新規作成する
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public RoomEntity CreateRoom(IEnumerable<UserEntity> members);
        /// <summary>
        /// 指定ユーザーが参加しているチャットルームを取得する
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<RoomEntity> GetRoomsByUser(UserEntity user);
        
    }
}
