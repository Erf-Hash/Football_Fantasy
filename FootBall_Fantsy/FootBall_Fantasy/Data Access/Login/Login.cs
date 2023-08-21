namespace FootBall_Fantasy.Data_Access.Login;
public class DataAccessLogin
{
    public static bool IsUserAvailable(string UserOrEmail, string Password)
    {
        using (var db = new DataBaseConfiguring())
        {
            var user = db.users.FirstOrDefault(x => x.UserName == UserOrEmail || x.Email == UserOrEmail);
            if (user != null)
            {
                if (user.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
