using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories
{
    public interface IUserRepository
    {
        UserEntity GetById(string user_id);
        List<UserEntity> GetAllUsers();
    }
}
