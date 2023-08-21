using FootBall_Fantasy.Business.CallAPI;

namespace Football_Fantasy_TestProject;

[TestClass]
public class CallAPITest
{
    [TestMethod]
    public void TestPlayer()
    {
        Assert.IsNotNull(CallAPI.GetPlayersFromFPL());
    }
    [TestMethod]
    public void TestTeam()
    {
        Assert.IsNotNull(CallAPI.GetTeamsFromFPL());
    }
}