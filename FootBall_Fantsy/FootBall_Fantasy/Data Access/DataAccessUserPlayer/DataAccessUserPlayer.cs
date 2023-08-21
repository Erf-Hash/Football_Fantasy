using FootBall_Fantasy.Business.Users;

namespace FootBall_Fantasy.Data_Access.DataAccessUserPlayer;

public class DataAccessUserPlayer
{
    public static List<UserPlayer> GetUserPlayers(int UserID)
    {
        List<UserPlayer> result;
        using(var DB = new DataBaseConfiguring())
        {
            result = DB.userPlayers.Where(x => x.userID == UserID).ToList();
        }
        return result;
    }
    public static void UpdateUserPlayers(int UserID , List<UserPlayer> players)
    {
        List<UserPlayer> result;
        using(var DB = new DataBaseConfiguring())
        {
            DB.userPlayers.RemoveRange(DB.userPlayers.Where(x => x.userID == UserID));
            DB.userPlayers.AddRange(players);
            DB.SaveChanges();
        }
    }

    public static void ClearTable()
    {
        using(var DB = new DataBaseConfiguring())
        {
            var x = DB.userPlayers;
            DB.userPlayers.RemoveRange(x);
        }
    }
}

