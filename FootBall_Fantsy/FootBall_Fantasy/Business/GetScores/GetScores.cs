using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Data_Access.DataAccessUser;
using ServiceStack;

namespace FootBall_Fantasy.Business.GetScores;

public class GetScores
{
    public static List<User> GetAllScores()
    {
        List<User> list = DataAccessUser.GetAllUsers();
        list = list.OrderByDescending(x => x.Score).ToList();
        return list;
    }
}
