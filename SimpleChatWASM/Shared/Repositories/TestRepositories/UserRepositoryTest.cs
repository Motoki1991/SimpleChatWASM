
using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories.TestRepositories
{
    public class UserRepositoryTest:IUserRepository
    {
        public UserRepositoryTest()
        {
            _users = SampleUsers.GetSampleUsers();
        }

        private List<UserEntity> _users = new List<UserEntity>();

        public UserEntity GetById(string user_id)
        {
            var result = _users.Where(w=>w.UserID == user_id).FirstOrDefault();
            if(result == null)
            {
                throw new Exception($"指定されたIDのユーザーが見つかりませんでした。[id={user_id}]");
            }
            return result;
        }
        public List<UserEntity> GetAllUsers()
        {
            return _users;
        }
        public bool TryAuth(string username, string password, out UserEntity userEntity)
        {
            var result = false;
            userEntity = _users.Where(w => w.UserID == username && w.LoginPassword == password).FirstOrDefault();
            if(userEntity != null)
            {
                result = true;
            }
            return result;
        }
    }
}
