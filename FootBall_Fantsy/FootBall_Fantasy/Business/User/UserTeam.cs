using FootBall_Fantasy.Business.Players;
using FootBall_Fantasy.Business.ResponseClass;
using FootBall_Fantasy.Data_Access.DataAccessPlayer;
using FootBall_Fantasy.Data_Access.DataAccessUserPlayer;
using FootBall_Fantasy.Data_Access.DataAccessTeam;
using System.ComponentModel.DataAnnotations;
using ServiceStack;

namespace FootBall_Fantasy.Business.Users;
public enum TeamStatus
{
    NotComplete,
    Complete
}
public enum PlayerRole
{
    Substitute,
    Fixed
}
public class UserPlayer
{
    public UserPlayer(int playerID, int userID, PlayerRole Role)
    {
        this.playerID = playerID;
        this.userID = userID;
        this.Role = Role;
    }
    public UserPlayer() { }
    public PlayerRole Role { get; set; }
    [Key]
    public int ID { get; set; }
    public int playerID { get; set; }
    public int userID { get; set; }
    public Player? GetPlayer()
    {
        return DataAccessPlayer.GetPlayerById(playerID);
    }
    public void Substitution()
    {
        Role = (Role == PlayerRole.Substitute) ? PlayerRole.Fixed : PlayerRole.Substitute;
    }
    public Filter.Position GetPlayerPosition()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return Filter.Position.Default;
        }
        return (Filter.Position)player.element_type;
    }
}
public class UserTeam
{
    public float Cash { get; set; }
    public TeamStatus Status { get; set; }
    public int userID { get; set; }
    public List<UserPlayer> Players { get; set; } = new List<UserPlayer>();
    public UserTeam(float Cash, int userID)
    {
        this.Cash = Cash;
        this.userID = userID;
        Players = DataAccessUserPlayer.GetUserPlayers(userID);
        Status = (Players.Count == 15) ? TeamStatus.Complete : TeamStatus.NotComplete;
    }
    private static Dictionary<Filter.Position, int> SquadSelect = new Dictionary<Filter.Position, int>()
    {
        { Filter.Position.Goalkeepers , 2},
        { Filter.Position.Defenders , 5},
        { Filter.Position.Midfielders , 5},
        { Filter.Position.Forwards , 3}
    };
    private static Dictionary<Filter.Position, int> SquadMinPlay = new Dictionary<Filter.Position, int>()
    {
        { Filter.Position.Goalkeepers , 1},
        { Filter.Position.Defenders , 3},
        { Filter.Position.Midfielders , 2},
        { Filter.Position.Forwards , 1}
    };
    private static Dictionary<Filter.Position, int> SquadMaxPlay = new Dictionary<Filter.Position, int>()
    {
        { Filter.Position.Goalkeepers , 1},
        { Filter.Position.Defenders , 5},
        { Filter.Position.Midfielders , 5},
        { Filter.Position.Forwards , 3}
    };
    private static Dictionary<Filter.Position, int> SquadDefaultPlay = new Dictionary<Filter.Position, int>()
    {
        { Filter.Position.Goalkeepers , 1},
        { Filter.Position.Defenders , 4},
        { Filter.Position.Midfielders , 3},
        { Filter.Position.Forwards , 3}
    };
    public List<Player?> GetPlayersByPosition(Filter.Position position)
    {
        if (position == Filter.Position.Default)
        {
            return Players.Select(x => x.GetPlayer()).ToList();
        }
        return Players.Where(x => x.GetPlayerPosition() == position).Select(x => x.GetPlayer()).ToList();
    }
    public List<Player?> GetFixedPlayersByPosition(Filter.Position position)
    {
        if (position == Filter.Position.Default)
        {
            return Players.Where(x => x.Role == PlayerRole.Fixed).Select(x => x.GetPlayer()).ToList();
        }
        return Players.Where(x => (x.GetPlayerPosition() == position) && (x.Role == PlayerRole.Fixed)).Select(x => x.GetPlayer()).ToList();
    }
    public List<Player?> GetSubstitutesPlayers()
    {
        return Players.Where(x => x.Role == PlayerRole.Substitute).Select(x => x.GetPlayer()).ToList();
    }
    public Response Add(int id)
    {
        Response response = new Response();
        var player = DataAccessPlayer.GetPlayerById(id);
        if (player == null)
            return new Response(false, "this player does not exist.");

        if (Players.Find(x => x.playerID == id) != null)
            return new Response(false, $"you have already added {player.first_name} {player.second_name}");

        if (Players.Count >= 15)
            return new Response(false, "you already have 15 players");

        if (Players.Count(x => x.GetPlayer().team == player.team) >= 3)
            return new Response(false, $"you can not add player from {DataAccessFPLTeam.GetFPLTeamById(player.team).name} team any more.");

        if (Players.Count(x => x.GetPlayer().element_type == player.element_type) >= SquadSelect[(Filter.Position)player.element_type])
            return new Response(false, $"you can not add to {(Filter.Position)player.element_type} any more.");

        if (Cash - ((float)player.now_cost / 10) < 0)
            return new Response(false, "you dont have enough money");

        var Role = (Players.Count(x => (x.GetPlayer().element_type == player.element_type && x.Role == PlayerRole.Fixed)) < SquadDefaultPlay[(Filter.Position)player.element_type]) ? PlayerRole.Fixed : PlayerRole.Substitute;
        Players.Add(new UserPlayer(id, userID, Role));
        if (Players.Count == 15) Status = TeamStatus.Complete;
        Cash -= (float)player.now_cost / 10;
        DataAccessUserPlayer.UpdateUserPlayers(userID, Players);
        return new Response(true, "player added successfuly.");
    }
    public Response Remove(int id)
    {
        var response = new Response();
        if (Players.Count == 0)
            return new Response(false, "you dont have any player yet.");

        if (Players.Find(x => x.playerID == id) == null)
            return new Response(false, "this player does not exist in your team.");

        var targetPlayer = (Players.Find(x => x.playerID == id));
        Players.Remove(targetPlayer);
        Status = TeamStatus.NotComplete;
        DataAccessUserPlayer.UpdateUserPlayers(userID, Players);
        Cash += (float)targetPlayer.GetPlayer().now_cost / 10;
        return new Response(true, $"{targetPlayer.GetPlayer().first_name} {targetPlayer.GetPlayer().second_name} has been removed successfuly");
    }
    public Response Substitution(int id_1, int id_2)
    {
        var response = new Response();
        if (Players.Find(x => x.playerID == id_1) == null || Players.Find(x => x.playerID == id_2) == null)
            return new Response(false, "player is null.");

        if (Status == TeamStatus.NotComplete)
            return new Response(false, "you must add all of players first.");

        if (Players.First(x => x.playerID == id_1).Role == Players.First(x => x.playerID == id_2).Role)
            return new Response(false, $"Two {Players.First(x => x.playerID == id_1).Role} players cannot be swaped.");

        if (Players.First(x => x.playerID == id_1).Role == PlayerRole.Fixed)
        {
            int temp = id_1;
            id_1 = id_2;
            id_2 = temp;
        }        
        var FixedPlayer = DataAccessPlayer.GetPlayerById(id_2);
        var SubstitutePlayer = DataAccessPlayer.GetPlayerById(id_1);
        if (FixedPlayer.element_type != SubstitutePlayer.element_type)
        {
            if (Players.Count(x => x.GetPlayer().element_type == FixedPlayer.element_type) <= SquadMinPlay[(Filter.Position)FixedPlayer.element_type])
                return new Response(false, $"you must have at least {SquadMinPlay[(Filter.Position)FixedPlayer.element_type]} players in {(Filter.Position)FixedPlayer.element_type} position.");

            if (Players.Count(x => x.GetPlayer().element_type == SubstitutePlayer.element_type) >= SquadMaxPlay[(Filter.Position)SubstitutePlayer.element_type])
                return new Response(false, $"you must have at most {SquadMaxPlay[(Filter.Position)SubstitutePlayer.element_type]} players in {(Filter.Position)SubstitutePlayer.element_type} position.");
        }
        Players[Players.FindIndex(x => x.playerID == id_2)].Substitution();
        Players[Players.FindIndex(x => x.playerID == id_1)].Substitution();
        DataAccessUserPlayer.UpdateUserPlayers(userID, Players);
        return new Response(true, "Substitution finished successfuly.");
    }
}
