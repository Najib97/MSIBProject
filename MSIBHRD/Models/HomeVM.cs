using MSIBHRD.Models.EF;

namespace MSIBHRD.Models
{
    public class HomeVM
    {
        public class Index
        {
            public User User { get; set; } = new User();
            public Index(ModelContext context, string session)
            {
                var Muser = context.Users.Where(x => x.Username == session).FirstOrDefault();
                if (Muser != null)
                {
                    User = Muser;
                }
            }
        }
    }
}
