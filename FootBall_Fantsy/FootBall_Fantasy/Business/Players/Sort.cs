using FootBall_Fantasy.Data_Access.DataAccessPlayer;
namespace FootBall_Fantasy.Business.Players
{

    public class Sort
    {
        public enum SortType
        {
            Default,
            PointSort,
            CostSort,
            NameSort,
            WebName
        }
        public enum SortOrder
        {
            Descending,
            Ascending
        }
        public static List<Player> SortBy(List<Player> players = null, SortType Type = SortType.Default, SortOrder order = SortOrder.Ascending)
        {
            List<Player> result;
            if (players == null)
            {
                players = DataAccessPlayer.GetAllPlayers();
            }
            switch (Type)
            {
                case SortType.PointSort:
                    if (order == SortOrder.Ascending) result = players.OrderBy(x => x.total_points).ToList();
                    else result = players.OrderByDescending(x => x.total_points).ToList();
                    break;
                case SortType.CostSort:
                    if (order == SortOrder.Ascending) result = players.OrderBy(x => x.now_cost).ToList();
                    else result = players.OrderByDescending(x => x.now_cost).ToList();
                    break;
                case SortType.NameSort:
                    if (order == SortOrder.Ascending) result = players.OrderBy(x => x.second_name).ToList();
                    else result = players.OrderByDescending(x => x.second_name).ToList();
                    break;
                case SortType.WebName:
                    if (order == SortOrder.Ascending) result = players.OrderBy(x => x.web_name).ToList();
                    else result = players.OrderByDescending(x => x.web_name).ToList();
                    break;
                default:
                    result = new List<Player>(players);
                    break;
            }
            return result;
        }
    }
}
