using FootBall_Fantasy.Data_Access.DataAccessPlayer;
using System.Globalization;

namespace FootBall_Fantasy.Business.Players;
public class PlayersManipulation
{
    public Sort.SortType sortType { get; set; }
    public Sort.SortOrder sortOrder { get; set; }
    public Filter.Position position { get; set; }
    public string? search { get; set; }
    public int paginationPage { get; set; }
    public int paginationLength { get; set; }
    public int teamID { get; set; } = 0;
    public PlayersManipulation(
        string search = null,
        Sort.SortType sortType = Sort.SortType.Default,
        Sort.SortOrder sortOrder = Sort.SortOrder.Ascending,
        Filter.Position position = Filter.Position.Default,
        int paginationPage = 0,
        int paginationLength = 20,
        int teamID = 0)
    {

        this.sortType = sortType;
        this.sortOrder = sortOrder;
        this.position = position;
        this.search = search;
        this.paginationPage = paginationPage;
        this.paginationLength = paginationLength;
        this.teamID = teamID;
    }
    public List<Player> GetManipulatedPlayers()
    {
        List<Player> players = DataAccessPlayer.GetAllPlayers();
        var Searched = Search.SearchBy(players, search);
        var Filtered = Filter.FilterByPositionAndTeam(Searched, position , teamID);
        var Sorted = Sort.SortBy(Filtered, sortType, sortOrder);
        var Paginated = Pagination.PaginationBy(Sorted, paginationPage, paginationLength);
        return Paginated;
    }
    
    public int GetLastPageIndex()
    {
        List<Player> players = DataAccessPlayer.GetAllPlayers();
        var Searched = Search.SearchBy(players, search);
        var Filtered = Filter.FilterByPositionAndTeam(Searched, position, teamID);
        return (int) Math.Ceiling((double)Filtered.Count / paginationLength);
    }
}

