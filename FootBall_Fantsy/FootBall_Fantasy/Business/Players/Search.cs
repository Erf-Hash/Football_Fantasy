using FootBall_Fantasy.Data_Access.DataAccessPlayer;
namespace FootBall_Fantasy.Business.Players
{
    public class Search
    {
        public static List<Player> SearchBy(List<Player> players = null, string str = null)
        {
            HashSet<Player> resultSet = new HashSet<Player>();
            if (players == null)
            {
                players = DataAccessPlayer.GetAllPlayers();
            }
            if (str == null)
            {
                return players;
            }
            List<string> strings = str.Trim(' ').Split(' ').ToList();
            foreach (string target in strings)
            {
                var matchingPlayers = players.Where(x =>
                    x.first_name.ToLower().Contains(target.ToLower()) ||
                    x.second_name.ToLower().Contains(target.ToLower()) ||
                    x.web_name.ToLower().Contains(target.ToLower()));
                foreach (var player in matchingPlayers)
                {
                    resultSet.Add(player);
                }
            }
            return resultSet.ToList();
        }
    }
}


