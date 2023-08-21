using FootBall_Fantasy.Business.Users;
using ServiceStack;

namespace FootBall_Fantasy.Data_Access.DataAccessUser;

public class DataAccessUser
{
    public static void AddRecord(User user)
    {
        using (var DB = new DataBaseConfiguring())
        {
            DB.users.Add(user);
            DB.SaveChanges();
        }
    }
    public static void UpdateCash(User user)
    {
        using (var DB = new DataBaseConfiguring())
        {
            DB.users.First(x => x.id == user.id).Cash = user.Cash;
            DB.SaveChanges();
        }
    }
    public static User? GetUserById(int? id)
    {
        if (id == null) return null;
        using (var DB = new DataBaseConfiguring())
        {
            return DB.users.FirstOrDefault(x => x.id == id);
        }
    }
    public static User? GetUserByUserOrEmail(string userOrEmail)
    {
        if (userOrEmail == null) return null;
        using (var DB = new DataBaseConfiguring())
        {
            return DB.users.FirstOrDefault(x => (x.UserName == userOrEmail || x.Email == userOrEmail));
        }
    }
    public static List<User> GetAllUsers()
    {
        using(var DB = new DataBaseConfiguring())
        {
            return DB.users.ToList();
        }
    }

    public static void UpdateUserScores()
    {
        using (var DB = new DataBaseConfiguring())
        {
            foreach(User user in DB.users)
            {
                int PlayerScore = 0;
                UserTeam team = new UserTeam(user.Cash, user.id);

                if (team.Status == TeamStatus.NotComplete)
                {
                    DB.users.First(x => x.id == user.id).Score = 0;
                    continue;
                }

                foreach (UserPlayer player in team.Players)
                {
                    int PlayerPoint = player.GetPlayer().event_points;

                    if (player.Role == PlayerRole.Fixed)
                    {
                        PlayerScore += 2 * PlayerPoint;
                    }
                    else
                    {
                        PlayerScore += PlayerPoint;
                    }
                }
                DB.users.First(x => x.id == user.id).Score = PlayerScore;
            }
            DB.SaveChanges();
        }
    }
}
