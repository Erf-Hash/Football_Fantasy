using FootBall_Fantasy.Business.Users;

namespace FootBall_Fantasy.Data_Access.SignUp;
public class DataAccessSignUp
{
    public static User? FindRecord(string userOrEmail)
    {
        using (var DB = new DataBaseConfiguring())
        {
            return DB.users.FirstOrDefault(x => x.UserName == userOrEmail || x.Email == userOrEmail);
        }
    }
}
