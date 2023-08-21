using FootBall_Fantasy.Business.CallAPI;
using FootBall_Fantasy.Business.Players;
using FootBall_Fantasy.Business.Teams;

namespace FootBall_Fantasy.Data_Access.DataAccessTeam;

public class DataAccessFPLTeam
{
    public static void UpdateTeams()
    {
        var teams = CallAPI.GetTeamsFromFPL();
        using (var DB = new DataBaseConfiguring())
        {
            if (DB.teams.Count() == 0)
            {
                DB.teams.AddRange(teams);
            }
            else
            {
                DB.teams.UpdateRange(teams);
            }
            DB.SaveChanges();
        }
    }
    public static List<FPLTeams> GetAllFPLTeams()
    {
        using (var DB = new DataBaseConfiguring())
        {
            return DB.teams.ToList();
        }
    }
    public static FPLTeams? GetFPLTeamById(int id)
    {
        using (var DB = new DataBaseConfiguring())
        {
            return DB.teams.FirstOrDefault(x => x.id == id);
        }
    }
    public static List<Player> GetPlayers(int TeamID)
    {
        using (var DB = new DataBaseConfiguring())
        {
            return DB.Players.Where(x => x.team == TeamID).ToList();
        }
    }
    public static List<FPLTeams> Search(string TeamName)
    {
        List<FPLTeams> teams = GetAllFPLTeams();
        HashSet<FPLTeams> resultSet = new HashSet<FPLTeams>();

        if (TeamName == string.Empty)
        {
            return teams;
        }

        List<string> strings = TeamName.Trim(' ').Split(' ').ToList();
        foreach (string target in strings)
        {
            var matchingTeams = teams.Where(x =>
                x.short_name.ToLower().Contains(target.ToLower()) ||
                x.name.ToLower().Contains(target.ToLower()));
            foreach (var team in matchingTeams)
            {
                resultSet.Add(team);
            }
        }
        return resultSet.ToList();
    }
}
