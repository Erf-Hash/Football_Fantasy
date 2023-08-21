using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.FPLTeams;
public class Teams
{
    public static object GetFPLTeams()
    {
        return JsonConvert.SerializeObject(Data_Access.DataAccessTeam.DataAccessFPLTeam.GetAllFPLTeams());
    }
}

