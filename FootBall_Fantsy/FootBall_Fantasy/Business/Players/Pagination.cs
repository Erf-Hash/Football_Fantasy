using FootBall_Fantasy.Data_Access.DataAccessPlayer;
namespace FootBall_Fantasy.Business.Players
{
    public class Pagination
    {
        public static List<Player> PaginationBy(List<Player> players = null, int page = 0, int length = 20)
        {
            int startIndex = length * (page - 1);
            List<Player> result = new List<Player>();
            if (players == null)
            {
                players = DataAccessPlayer.GetAllPlayers();
            }
            if ((length * (page - 1) >= players.Count))
            {
                return result;
            }
            if (((length * page) - 1) >= players.Count)
            {
                length = players.Count - startIndex;
            }
            result.AddRange(players.GetRange(startIndex, length));
            return result;
        }
    }
}
