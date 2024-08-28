using SimpleChatWASM.Shared.Entities;

namespace SimpleChatWASM.Shared.Repositories.TestRepositories
{
    public static class SampleUsers
    {
        private static List<UserEntity> _sample_users = new List<UserEntity>()
        {
            new UserEntity(){UserID="tsuruda",UserName="鶴田",LoginPassword="tsuruda"},
            new UserEntity(){UserID="tanaka",UserName="田中",LoginPassword="tanaka"},
            new UserEntity(){UserID="furukawa",UserName="古川",LoginPassword="furukawa"},
            new UserEntity(){UserID="imamura",UserName="今村",LoginPassword="imamura"},
            new UserEntity(){UserID="komuro",UserName="小室",LoginPassword="komuro"},
            new UserEntity(){UserID="matsunaga",UserName="松永",LoginPassword="matsunaga"},
            new UserEntity(){UserID="abe",UserName="阿部",LoginPassword="abe"},
            new UserEntity(){UserID="tamori",UserName="太森",LoginPassword="tamori"},
            new UserEntity(){UserID="imaizumi",UserName="今泉",LoginPassword="imaizumi"},
            new UserEntity(){UserID="negi",UserName="根木",LoginPassword="negi"},
            new UserEntity(){UserID="satou",UserName="佐藤",LoginPassword="satou"},

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
