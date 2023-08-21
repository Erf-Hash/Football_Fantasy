namespace FootBall_Fantasy.Business.Users;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public float Cash { get; set; } = 100f;
    public float Score { get; set; } = 0;

    public User(TempUser tempUser)
    {
        Name = tempUser.Name;
        Email = tempUser.Email;
        Password = tempUser.Password;
        UserName = tempUser.UserName;
        Score = 0;
        Cash = 100f;
    }
    public User(string Name, string Email, string Pasword, int id, string UserName, float Cash, float Score)
    {
        this.Name = Name;
        this.Email = Email;
        this.Password= Pasword;
        this.id = id;
        this.UserName = UserName;
        this.Score = Score;
        this.Cash = Cash;
    }
    public User() { }
}