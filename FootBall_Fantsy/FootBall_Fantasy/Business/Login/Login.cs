using FootBall_Fantasy.Data_Access;
using FootBall_Fantasy.Data_Access.Login;

namespace FootBall_Fantasy.Business.Login
{
    public static class Login
    {
        public static bool CheckCredential(string userOrEmail, string password) => DataAccessLogin.IsUserAvailable(userOrEmail, password);
    }
}
