using FootBall_Fantasy.Data_Access.DataAccessTempUser;

namespace FootBall_Fantasy.Business.Users
{
    public class TempUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime BuildTime { get; set; }
        public TempUser(string Name , string Email , string Password , string UserName)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.UserName = UserName;
            BuildTime = DateTime.Now;
        }
    }
    public class TempUserHandler
    {
        public static void AddTempUser(TempUser tempUser)
        {
            DataAccessTempUser.AddRecord(tempUser);
        }
        public static void VerifyUser(string Email)
        {
            var tempUser = DataAccessTempUser.FindByEmail(Email);
            DataAccessTempUser.MoveToUserTable(tempUser);
        }
    }
}
