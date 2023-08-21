using FootBall_Fantasy.Business.GetScores;
using Newtonsoft.Json;

namespace FootBall_Fantasy.Presentation.Ranking;

public class Ranking
{
    public static object ShowRanking()
    {
        var RankList = GetScores.GetAllScores();
        return JsonConvert.SerializeObject(RankList.Select(x => new {x.Name, x.Score, x.UserName}));
    }
}
