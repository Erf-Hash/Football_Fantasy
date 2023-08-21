using FootBall_Fantasy.Business.Players;
using FootBall_Fantasy.Business.CallAPI;
namespace FootBall_Fantasy.Data_Access.DataAccessPlayer;
public class DataAccessPlayer
{
    public static List<Player> GetAllPlayers()
    {
        using(var DB = new DataBaseConfiguring())
        {
            return DB.Players.ToList();
        }
    }
    public static Player? GetPlayerById(int id)
    {
        using(var DB = new DataBaseConfiguring())
        {
            return DB.Players.FirstOrDefault(x => x.Id == id);
        }
    }
    public static void UpdatePlayers()
    {
        var players = CallAPI.GetPlayersFromFPL();
        using (var DB = new DataBaseConfiguring())
        {
            if (DB.Players.Count() == 0)
            {
                DB.Players.AddRange(players);
            }
            else
            {
                DB.Players.UpdateRange(players);
            }
            DB.SaveChanges();
        }
    }
}
