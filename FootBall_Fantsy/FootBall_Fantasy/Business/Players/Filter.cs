using FootBall_Fantasy.Data_Access.DataAccessPlayer;
namespace FootBall_Fantasy.Business.Players
{
    public class Filter
    {
        public enum Position
        {
            Default,
            Goalkeepers,
            Defenders,
            Midfielders,
            Forwards
        }
        public static List<Player> FilterByPositionAndTeam(List<Player> players = null, Position position = Position.Default , int teamID = 0)
        {
            List<Player> result;
            if (players == null)
            {
                players = DataAccessPlayer.GetAllPlayers();
            }
            if (position == Position.Default)
            {
                if (teamID == 0)
                {
                    result = new List<Player>(players);
                    return result;
                }
                return players.Where(x => x.team == teamID).ToList();
            }
            if (teamID == 0)
            {
                result = players.Where(x => x.element_type == (int)position).ToList();
                return result;
            }
            result = players.Where(x => (x.element_type == (int)position && x.team == teamID)).ToList();
            return result;
        }
    }
}
