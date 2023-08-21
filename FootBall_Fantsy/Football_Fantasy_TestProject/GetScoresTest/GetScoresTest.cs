using FootBall_Fantasy.Business.GetScores;

namespace Football_Fantasy_TestProject;

[TestClass]
public class GetScoresTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsNotNull(GetScores.GetAllScores());
    }
}