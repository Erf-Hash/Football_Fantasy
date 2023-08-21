using FootBall_Fantasy.Business.Players;
using Newtonsoft.Json;
using RestSharp;

namespace FootBall_Fantasy.Business.CallAPI;

public class PlayerList
{
    public List<Player> elements { get; set; }
}
public class CallAPI
{
    public static List<Player> GetPlayersFromFPL()
    {
        var client = new RestClient("https://fantasy.premierleague.com");
        var request = new RestRequest("/api/bootstrap-static/", Method.Get);
        var response = client.Execute(request);
        var json = response.Content;
        var data = JsonConvert.DeserializeObject<dynamic>(json);
        var elements = data["elements"];
        var players = JsonConvert.DeserializeObject<List<Player>>(JsonConvert.SerializeObject(elements));
        return players;
    }
    public static List<Teams.FPLTeams> GetTeamsFromFPL()
    {
        var client = new RestClient("https://fantasy.premierleague.com");
        var request = new RestRequest("/api/bootstrap-static/", Method.Get);
        var response = client.Execute(request);
        var json = response.Content;
        var data = JsonConvert.DeserializeObject<dynamic>(json);
        var teams = data["teams"];
        var result = JsonConvert.DeserializeObject<List<Teams.FPLTeams>>(JsonConvert.SerializeObject(teams));
        return result;
    }
}
