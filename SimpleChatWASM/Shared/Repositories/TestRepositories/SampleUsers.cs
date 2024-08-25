using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories.TestRepositories
{
    public static class SampleUsers
    {
        private static List<UserEntity> _sample_users = new List<UserEntity>()
        {
            new UserEntity(){UserID="tsuruda",UserName="鶴田　太郎"},
            new UserEntity(){UserID="tanaka",UserName="田中　次郎"},
            new UserEntity(){UserID="satou",UserName="佐藤　三郎"},
        };

        public static List<UserEntity> GetSampleUsers()
        {
            return _sample_users;
        }
        public static UserEntity GetSampleUser(string user_id)
        {
            var user = _sample_users.Where(w => w.UserID==user_id).FirstOrDefault();
            if(user == null)
            {
                user = new UserEntity()
                {
                    UserID = user_id,
                    UserName = "アリストテレス",
                };
                return user;
            }
            else
            {
                return user;
            }
        }
    }
}
